using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Auth.Domain.Entities;
using Auth.Domain.Entities.AuthEntities;

namespace Auth.Infrastructure.Helpers
{
    public class UserProps
    {
        public User SetUserProp(RegisModel regisModel)
        {
            User user = new User();
            user.nickName = regisModel.nickName;
            user.email = regisModel.email;
            user.birthDate = null;
            user.subcriptions = null;
            user.subscribers = null;
            user.posts = null;
            user.storiesList = null;
            user.savedPosts = null;
            user.privateProfile = false;
            return user;
        }
    }
}
