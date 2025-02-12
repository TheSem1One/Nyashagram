using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Helpers
{
    internal class HashPassword
    {
        public string PasswordHashing(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            string HashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return HashedPassword;
        }

        
    }
}
