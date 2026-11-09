using System;
using System.Security.Cryptography;
using System.Text;

namespace PR3.Services
{
    public class Hash
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] sourceBytePassword = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(sourceBytePassword);

                return Convert.ToBase64String(hash);
            }
        }
    }
}
