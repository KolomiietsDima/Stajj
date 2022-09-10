using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Staj
{
    public class PasswordHash
    {
        public static string CreatePasswordHash(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }
        public static bool VerifyPasswordHash(string password, string passwordHash)
        {
            bool verified = BCrypt.Net.BCrypt.Verify(password, passwordHash);
            return verified;
        }
    }
}
