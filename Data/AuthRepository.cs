using dotnet_ef_simple_rpg_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ef_simple_rpg_web_api.Data;

public class AuthRepository : IAuthRepository
{
    private readonly DataContext _dataContext;

    public AuthRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
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
            response.Data = user.Id.ToString();
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
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
