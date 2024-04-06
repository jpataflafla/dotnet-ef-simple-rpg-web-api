namespace dotnet_ef_simple_rpg_web_api.Data;
public static class AuthUtility
{
    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
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

    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            var computedHash = hmac.ComputeHash(passwordBytes);
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}