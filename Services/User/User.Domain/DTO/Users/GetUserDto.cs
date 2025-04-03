namespace User.Domain.DTO.Users
{
    public class GetUserDto
    {
        public string NickName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public DateOnly? BirthDate { get; set; }
        public string? Description { get; set; }
        public List<string> Subscriptions { get; set; }
        public List<string> Subscribers { get; set; }
        public List<string> StoriesList { get; set; } 
    }
}
