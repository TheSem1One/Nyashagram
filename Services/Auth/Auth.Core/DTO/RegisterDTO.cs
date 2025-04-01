namespace User.Domain.DTO
{
    public class RegisterDto
    {
        public string NickName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
