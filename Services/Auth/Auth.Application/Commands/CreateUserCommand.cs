using Auth.Application.Responses;
using Auth.Domain.DTO;
using MediatR;

namespace Auth.Application.Commands
{
    public class CreateUserCommand : IRequest<RegisterResponse>
    {
        public string NickName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public CreateUserCommand(string nickName, string email, string password)
        {
            NickName = password;
            Email = email;
            Password = password;
        }

    }
}
