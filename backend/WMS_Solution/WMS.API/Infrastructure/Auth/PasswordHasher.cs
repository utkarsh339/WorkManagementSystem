using System.Security.Cryptography;
using System.Text;

namespace WMS.API.Infrastructure.Auth
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool verify(string password, string hash)
        {
            return Hash(password) == hash;
        }
    }
}
