using User.Application.Responses;
using MediatR;

namespace User.Application.Commands
{
    public class LoginUserCommand : IRequest<AuthResponse>
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
