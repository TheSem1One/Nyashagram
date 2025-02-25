using System.Reflection.PortableExecutable;
using Auth.Application.Responses;
using MediatR;

namespace Auth.Application.Commands
{
    class LoginUserCommand : IRequest<RegisterResponse>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
