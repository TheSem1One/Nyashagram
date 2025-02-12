using Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Infrastructure.Persistence;

namespace Auth.Infrastructure.Configuration
{
    public class FindUser
    {
        private readonly Modelcontext _db;

        public FindUser(Modelcontext db)
        {
            _db = db;
        }

        public User? GetUserByEmail(string email)
        {
            return _db.Users.SingleOrDefault(user => user.email.ToLower() == email.ToLower());

        }
    }
}
