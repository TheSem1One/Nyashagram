using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Infrastructure.Persistence;

namespace Auth.Infrastructure.Helpers
{
    public class UserIdentity
    {
        private readonly UserContext _db;
        private readonly HashPassword _hashPassword;
        public UserIdentity(UserContext db, HashPassword hashPassword)
        {
            _db = db;
            _hashPassword = hashPassword;

        }
        public bool IsEqual(string email, string password)
        {
            var hashPassword = _hashPassword.HashingPassword(password, out var salt);
            var user = _db.Users.SingleOrDefault(user => user.email.ToLower() == email.ToLower());
            return (user.email == email && user.password == hashPassword);
        }
    }
}
