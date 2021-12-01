using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatAPI.Classes
{
    public static class HashPassword
    {
        public static string Hash(string password, string salt)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(salt + password);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }
    }
}