using System.Security.Cryptography;
using System.Text;
using API.Model;

namespace API.Utilities
{
    public static class PasswordSerialization
    {
        public static SerializedPassword HashPassword(string plaintextPassword)
        {
            // ? Hash and salt the user's creds
            using var hmac = new HMACSHA512();

            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(plaintextPassword));

            return new SerializedPassword
            {
                PasswordHash = passwordHash,
                PasswordSalt = hmac.Key,
            };
        }

        public static bool VerifyPassword(string plaintextPassword, byte[] hash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(plaintextPassword));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != hash[i]) return false;
            }

            return true;
        }
    }
}
