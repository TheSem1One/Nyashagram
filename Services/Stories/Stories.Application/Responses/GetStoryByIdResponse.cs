namespace Stories.Application.Responses
{
    public class GetStoryByIdResponse
    {
        public string? StoriesId { get; set; }
        public string StoriesImageUrl { get; set; }
        public string CreatorNickName { get; set; }
        public int? Likes { get; set; }
    }
}
