using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Post.Domain.Entities;

namespace Post.Application.Responses
{
    public class GetPostByIdResponse{
    
        public string? PostId { get; set; }
         
        public string PostImageUrl { get; set; }

       
        public string CreatorNickName { get; set; }

    
        public string Descriptions { get; set; }

        
        public DateTime CreateDateTime { get; set; }

         
        public List<Comment>? Comments { get; set; }

        
        public Like? Likes { get; set; }
    }
}
