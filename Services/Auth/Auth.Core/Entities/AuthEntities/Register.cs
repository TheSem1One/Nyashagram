using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Entities.AuthEntities
{
    public class Register : User
    {
        public string NickName;
        public string Email;
        public string Password;
    }
}
