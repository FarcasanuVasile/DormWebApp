using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DormWebApp.Services.Services
{
    public class SecurityServices
    {
        public static string PasswordHash(string password)
        {
            var salt = "QxLUF1bgIAdeQX";
            var combinedPassword = string.Concat(salt, password);
            var sha = new SHA256Managed();
            var bytes = UTF8Encoding.UTF8.GetBytes(combinedPassword);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
