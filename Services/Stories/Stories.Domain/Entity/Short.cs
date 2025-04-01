using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Stories.Domain.Entity
{
    public class Short
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? StoryId { get; set; }

        [BsonElement("StoriesImageUrl"), BsonRepresentation(BsonType.String)]
        public string StoryImageUrl { get; set; } = null!;

        [BsonElement("CreatorNickName"), BsonRepresentation(BsonType.String)]
        public string CreatorNickName { get; set; } = null!;

        [BsonElement("ExpireTime"), BsonRepresentation(BsonType.DateTime)]
        public DateTime ExpireTime { get; set; }

        [BsonElement("Likes"), BsonRepresentation(BsonType.Int64)]
        public int? Likes { get; set; }


    }
}
