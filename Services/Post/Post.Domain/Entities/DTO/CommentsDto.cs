namespace Post.Domain.Entities.DTO
{
    public class CommentsDto
    {
        public string PostId { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
