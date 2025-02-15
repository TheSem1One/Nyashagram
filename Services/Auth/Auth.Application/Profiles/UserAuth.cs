using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Auth.Domain.Entities;
using Auth.Domain.Entities.AuthEntities;
using Auth.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Auth.Application.Profiles
{
    public class UserAuth
    {
        public void UserLogin(LogModel logModel)
        {

        }



        public void UserRegister(RegisModel regModel)
        {
            User user = SetUser(regModel);
        }
    }
}
