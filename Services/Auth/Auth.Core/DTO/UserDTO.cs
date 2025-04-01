namespace User.Domain.DTO
{
    public class UserDTO
    {
        public string NickName { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<string>? Subcriptions { get; set; }
        public List<string>? Subscribers { get; set; }
        public List<string>? Posts { get; set; }
        public List<string>? StoriesList { get; set; }
        public List<string>? SavedPosts { get; set; }
        public bool PrivateProfile { get; set; }
    }
}
