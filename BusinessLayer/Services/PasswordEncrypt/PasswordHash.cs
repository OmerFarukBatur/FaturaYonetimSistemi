using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.PasswordEncrypt
{
    public static class PasswordHash
    {
        public static string PasswordHashCreate(string password)
        {
            ConfigurationManager configuration = new();
            string securitykey = configuration.GetValue<string>("SecurityKey");
            SHA256 sha = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password+securitykey);
            var hashedPassword = sha.ComputeHash(passwordBytes);
            return Convert.ToHexString(hashedPassword);
        }
    }
}
