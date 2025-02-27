using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Post.Domain.Entities
{
    public class Comment
    {
        [BsonElement("CommentatorNickName"), BsonRepresentation(BsonType.String)]
        public string ComentatorNickName { get; set; }

        [BsonElement("Notes"), BsonRepresentation(BsonType.String)]
        public string Notes { get; set; }
    }
}
