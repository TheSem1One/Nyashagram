namespace Post.Domain.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostImageUrl { get; set; }
        public string CreatorNickName { get; set; }
        public string Descriptions { get; set; }
        public DateTime CreateDateTime { get;set; }
        public List<Comment> Comments { get; set; }
        public Like Likes { get; set; }

    }
}
