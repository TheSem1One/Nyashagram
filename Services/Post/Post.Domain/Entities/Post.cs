using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Post.Domain.Entities
{
    public class Post
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? PostId { get; set; }

        [BsonElement("PostImageUrl"), BsonRepresentation(BsonType.String)]
        public string ImageUrl { get; set; } = null!;

        [BsonElement("CreatorNickName"), BsonRepresentation(BsonType.String)]
        public string CreatorNickName { get; set; } = null!;

        [BsonElement("Descriptions"), BsonRepresentation(BsonType.String)]
        public string Descriptions { get; set; } = null!;

        [BsonElement("CreateDateTime"), BsonRepresentation(BsonType.DateTime)]
        public DateTime CreateDateTime { get; set; }

        [BsonElement("Comments")] public List<Comment> Comments { get; set; } = new List<Comment>();

        [BsonElement("Likes")] public Like Likes { get; set; } = new Like();

    }
    public class Like
    {
        [BsonElement("CountLike"), BsonRepresentation(BsonType.Int64)]
        public int CountLike { get; set; }

        [BsonElement("LikerNickName")] public List<string> LikesNickName { get; set; } = new List<string>();
    }
    public class Comment
    {
        [BsonElement("CommentatorNickName"), BsonRepresentation(BsonType.String)]
        public string? ComentatorNickName { get; set; }

        [BsonElement("Notes"), BsonRepresentation(BsonType.String)]
        public string? Notes { get; set; }
    }
}
