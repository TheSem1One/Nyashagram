namespace User.Domain.DTO.Auth
{
    public class RegisterDto
    {
        public string NickName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
