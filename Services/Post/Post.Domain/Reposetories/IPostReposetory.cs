namespace Post.Domain.Reposetories
{
    public interface IPostReposetory
    {
        Task<IEnumerable<Entities.Post>> GetPost();
        Task<IEnumerable<Entities.Post>> GetPostByNickName(string nickName);
        Task<Entities.Post> GetPostById(string id);
        Task<Entities.Post> CreatePost(Entities.Post post);
        Task<bool> UpdateProduct(Entities.Post post);
        Task<bool> DeletePost(string id);
    }
}
