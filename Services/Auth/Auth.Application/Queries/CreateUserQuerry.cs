using Auth.Application.Responses;
using MediatR;

namespace Auth.Application.Queries
{
    public class CreateUserQuerry : IRequest<RegisterResponse>
    {
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }

        public CreateUserQuerry(string email,string nickName,string password)
        {
            Email = email;
            NickName = nickName;
            Password = password;
            
        }
    }
}
