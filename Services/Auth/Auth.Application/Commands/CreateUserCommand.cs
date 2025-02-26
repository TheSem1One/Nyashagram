using Auth.Application.Responses;
using MediatR;

namespace Auth.Application.Commands
{
    public class CreateUserCommand : IRequest<AuthResponse>
    {
        public string NickName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public CreateUserCommand(string nickName, string email, string password)
        {
            NickName = nickName;
            Email = email;
            Password = password;
        }

    }
}
