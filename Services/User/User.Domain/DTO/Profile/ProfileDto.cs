namespace User.Domain.DTO.Profile
{
    public class ProfileDto
    {
        public string NickName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public DateOnly? BirthDate { get; set; }
        public string? Description { get; set; }
        public List<string> Subscriptions { get; set; } = new List<string>();
        public List<string> Subscribers { get; set; } = new List<string>();
        public List<string> Posts { get; set; } = new List<string>();
        public List<string> StoriesList { get; set; } = new List<string>();
        public List<string> SavedPosts { get; set; } = new List<string>();
    }
}
