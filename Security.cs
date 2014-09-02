using System;
using System.Text;
using System.Security.Cryptography;

namespace EzUploadin
{
    class Security
    {
        internal static string HashPassword(string plain)
        {
            byte[] bytes1 = Encoding.Default.GetBytes(plain+plain);
            byte[] bround1 = new SHA512CryptoServiceProvider().ComputeHash(bytes1);
            string round1 = Encoding.Default.GetString(bround1);
            byte[] bytes2 = Encoding.Default.GetBytes(round1+round1);
            byte[] bround2 = new SHA512CryptoServiceProvider().ComputeHash(bytes2);
            return Encoding.Default.GetString(bround2);
        }
    }
}
