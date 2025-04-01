namespace Stories.Application.Responses
{
    public class GetStoryByIdResponse
    {
        public string? StoriesId { get; set; }
        public string StoriesImageUrl { get; set; } = null!;
        public string CreatorNickName { get; set; } = null!;
        public int? Likes { get; set; }
    }
}
