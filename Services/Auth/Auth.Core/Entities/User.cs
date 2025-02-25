namespace Auth.Domain.Entities 
{
   public class User 
    {
        public int userId { get; set; }
        public string nickName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime? birthDate { get; set; }
        public List<string>? subcriptions { get; set; }
        public List<string>? subscribers { get;set; }
        public List<string>? posts { get; set; }
        public List<string>? storiesList { get; set; }
        public List<string>? savedPosts { get; set; }
        public bool privateProfile { get; set; }



    }
}
