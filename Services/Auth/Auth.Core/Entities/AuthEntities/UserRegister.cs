
namespace Auth.Domain.Entities.AuthEntities
{
    public class UserRegister
    {
        public string NickName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
