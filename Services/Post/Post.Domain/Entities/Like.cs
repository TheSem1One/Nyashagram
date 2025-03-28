using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Post.Domain.Entities
{
    public class Like
    {
        [BsonElement("CountLike"), BsonRepresentation(BsonType.Int64)]
        public int CountLike { get; set; }

        [BsonElement("LikerNickName")]
        public List<string> LikerNickName { get; set; }
    }
}
