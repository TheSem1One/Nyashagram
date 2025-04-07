using Post.Domain.Entities.DTO;

namespace Post.Domain.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Entities.Post>> GetPost();
        Task<IEnumerable<Entities.Post>> GetPostByNickName(string nickName);
        Task<Entities.Post> GetPostById(string id);
        Task<string> CreatePost(PostDto postDto);
        Task<bool> DeletePost(string id);
        Task<bool> Comments(CommentsDto comments);
    }
}
