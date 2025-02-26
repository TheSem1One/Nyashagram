using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.DTO
{
    public class UserDTO
    {
        public string NickName { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<string>? Subcriptions { get; set; }
        public List<string>? Subscribers { get; set; }
        public List<string>? Posts { get; set; }
        public List<string>? StoriesList { get; set; }
        public List<string>? SavedPosts { get; set; }
        public bool PrivateProfile { get; set; }
    }
}
