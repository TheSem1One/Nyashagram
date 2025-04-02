namespace User.Domain.DTO
{
    public class UserDTO
    {
        public string NickName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Desciption { get; set; }
        public List<string>? Subscriptions { get; set; }
        public List<string>? Subscribers { get; set; }
        public List<string>? Posts { get; set; }
        public List<string>? StoriesList { get; set; }
        public List<string>? SavedPosts { get; set; }
    }
}
