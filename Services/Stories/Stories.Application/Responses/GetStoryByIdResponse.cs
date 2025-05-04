using Stories.Domain.Entity;

namespace Stories.Application.Responses
{
    public class GetStoryByIdResponse
    {
        public string? StoryId { get; set; }
        public string StoryImageUrl { get; set; } = null!;
        public string CreatorNickName { get; set; } = null!;
        public Like? Likes { get; set; } = new();
    }
}
