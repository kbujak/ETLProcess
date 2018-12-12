
using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace ETL.Helpers
{
    public class HashGenerator
    { 
        public static Int32 GetEncodedHash(string password, string salt = "123")
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] digest = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password + salt));
            var r = BitConverter.ToInt32(digest, 0);
            if (r > 0) return r;
            else return -r;
            //string base64digest = Convert.ToBase64String(digest, 0, digest.Length);
            //return base64digest.Substring(0, base64digest.Length - 2);
        }

    }
}
