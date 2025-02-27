using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Post.Domain.Entities
{
    public class Post
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string PostId { get; set; }

        [BsonElement("PostImageUrl"), BsonRepresentation(BsonType.String)]
        public string PostImageUrl { get; set; }

        [BsonElement("CreatorNickName"), BsonRepresentation(BsonType.String)]
        public string CreatorNickName { get; set; }

        [BsonElement("Descriptions"), BsonRepresentation(BsonType.String)]
        public string Descriptions { get; set; }

        [BsonElement("CreateDateTime"), BsonRepresentation(BsonType.DateTime)]
        public DateTime CreateDateTime { get; set; }

        [BsonElement("Comments")]
        public List<Comment> Comments { get; set; }

        [BsonElement("Likes")]
        public Like Likes { get; set; }

    }
}
