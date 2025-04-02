namespace User.Domain.DTO
{
    public class ProfileDto
    {
        public string NickName { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Description { get; set; }
    }
}
