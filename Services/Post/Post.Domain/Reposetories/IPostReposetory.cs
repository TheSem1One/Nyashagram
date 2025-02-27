namespace Post.Domain.Reposetories
{
    public interface IPostReposetory
    {
        Task<Entities.Post> CreatePost(Entities.Post post);
        Task<bool> UpdateProduct(Entities.Post post);
        Task<bool> DeletePost(string id);
        Task<IEnumerable<Entities.Post>> GetAllPost();
        Task<Entities.Post> GetPost(string id);

    }
}
