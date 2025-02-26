﻿using System.Security.Cryptography;
using System.Text;

namespace Auth.Infrastructure.Helpers
{
    public class HashPassword
    {

        public string HashingPassword(string password)
        {
            using (var sha128 = SHA1.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha128.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hash);
            }
        }

    }
}