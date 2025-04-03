namespace User.Domain.DTO.Profile
{
    public class UpdateProfileDto
    {
        public string NickName { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? BirthDate { get; set; }
        public string? Description { get; set; }

    }
}
