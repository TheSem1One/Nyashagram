using MongoDB.Driver;
using Post.Domain.Reposetories;
using Post.Infrastructure.Presistence;

namespace Post.Infrastructure.Repositories
{
    public class PostReposetories : IPostReposetory
    {
        private IPostContext _context { get; }
          PostReposetories(IPostContext context)
        {
            _context = context;
        }

        async Task<IEnumerable<Domain.Entities.Post>> IPostReposetory.GetAllPost()
        {
            return await _context
                .Post
                .Find(post => true)
                .ToListAsync();
        }

        async Task<Domain.Entities.Post> IPostReposetory.GetPost(string id)
        {
            return await _context
                .Post
                .Find(post => post.PostId == id)
                .FirstOrDefaultAsync();
            ;
        }

        Task<Domain.Entities.Post> IPostReposetory.CreatePost(Domain.Entities.Post post)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPostReposetory.DeletePost(string id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPostReposetory.UpdateProduct(Domain.Entities.Post post)
        {
            throw new NotImplementedException();
        }
    }
}
