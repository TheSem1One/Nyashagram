﻿namespace User.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set;}
        public DateTime? BirthDate { get; set; }
        public List<string>? Subscriptions { get; set; }
        public List<string>? Subscribers { get; set; }
        public List<string>? Posts { get; set; }
        public List<string>? StoriesList { get; set; }
        public List<string>? SavedPosts { get; set; }
        public bool PrivateProfile { get; set; }



    }
}
