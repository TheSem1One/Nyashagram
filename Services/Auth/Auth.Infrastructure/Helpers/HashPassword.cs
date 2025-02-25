using System.Security.Cryptography;
using System.Text;

namespace Auth.Infrastructure.Helpers
{
    public class HashPassword
    {
        private const int keySize = 64;
        private const int iterations = 35000;


        public string HashingPassword(string password, out byte[] salt)
        {
            var hashAlgorithm = HashAlgorithmName.SHA512;
            salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password),
                salt, iterations, hashAlgorithm, keySize);

            return Convert.ToHexString(hash);

        }


    }
}
