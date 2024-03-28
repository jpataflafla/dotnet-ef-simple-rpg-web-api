using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using dotnet_ef_simple_rpg_web_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_ef_simple_rpg_web_api.Data;

public class AuthRepository : IAuthRepository
{
    private readonly DataContext _dataContext;
    private readonly IConfiguration _configuration;

    public AuthRepository(DataContext dataContext, IConfiguration configuration)
    {
        _dataContext = dataContext;
        _configuration = configuration;
    }

    public async Task<ServiceResponse<string>> Login(string username, string password)
    {
        var response = new ServiceResponse<string>();

        var user = await _dataContext.Users
            .SingleOrDefaultAsync(user => user.Username.ToLower() == username.ToLower());

        if (user is null)
        {
            response.Success = false;
            response.Message = $"User '{username}' not found.";
        }
        else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            response.Success = false;
            response.Message = "Incorrect password.";
        }
        else
        {
            response.Data = CreateToken(user);
        }

        return response;
    }

    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
        var response = new ServiceResponse<int>();

        if (await UserExists(user.Username))
        {
            response.Success = false;
            response.Message = $"User with username '{user.Username}' is already registered.";

            return response;
        }

        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _dataContext.Users.Add(user);
        await _dataContext.SaveChangesAsync();

        response.Data = user.Id;

        return response;
    }

    public async Task<bool> UserExists(string username)
    {
        return await _dataContext.Users.AnyAsync(user => user.Username.ToLower() == username.ToLower());
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        // Using a cryptographic HMACSHA512 algorithm for hashing
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            // Generating a random salt (key) for password hashing
            passwordSalt = hmac.Key;
            // Computing the hash value for the given password using UTF-8 encoding
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            passwordHash = hmac.ComputeHash(passwordBytes);
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            var computedHash = hmac.ComputeHash(passwordBytes);
            return computedHash.SequenceEqual(passwordHash);
        }
    }

    private string CreateToken(User user)
    {
        // Create a list of claims containing user information, such as ID and username
        var claims = new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        };

        // Retrieve the token secret from the application settings, db or some key vault
        var appSettingsToken = _configuration.GetSection("AppSettings:Token").Value
                                ?? throw new Exception("AppSettings 'Token' not found or is null.");

        var appSettingsBytes = System.Text.Encoding.UTF8.GetBytes(appSettingsToken);

        // Create a new symmetric security key using the token secret bytes
        var key = new SymmetricSecurityKey(appSettingsBytes);

        // Create signing credentials using the security key and HMAC-SHA512 signature algorithm
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        // Create a token descriptor with the specified claims, expiration time, and signing credentials
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(90),
            SigningCredentials = credentials
        };

        // Create a JWT security token handler
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token); //return token as a string
    }
}
