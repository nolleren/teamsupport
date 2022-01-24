using System.Security.Cryptography;
using System.Text;

namespace BLL.Helpers
{
    public static class PasswordHelper
    {
        public static string PasswordHash(string password, string email)
        {
            // Initialize the keyed hash object using the secret key as the key
            HMACSHA256 hashObject = new HMACSHA256(Encoding.UTF8.GetBytes(email));

            // Computes the signature by hashing the salt with the secret key as the key
            var signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Base 64 Encode
            var encodedSignature = Convert.ToBase64String(signature);

            return encodedSignature;

        }
    }
}
