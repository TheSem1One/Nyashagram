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

        async Task<IEnumerable<Domain.Entities.Post>> IPostReposetory.GetPost()
        {
            return await _context
                .Post
                .Find(post => true)
                .ToListAsync();
        }
        async Task<IEnumerable<Domain.Entities.Post>> IPostReposetory.GetPostByNickName(string nickName)
        {
            return await _context.Post
                .Find(p => p.CreatorNickName.ToLower() == nickName.ToLower())
                .ToListAsync();
        }
        async Task<Domain.Entities.Post> IPostReposetory.GetPostById(string id)
        {
            return await _context
                .Post
                .Find(post => post.PostId == id)
                .FirstOrDefaultAsync();
        }

        async Task<Domain.Entities.Post> IPostReposetory.CreatePost(Domain.Entities.Post post)
        {
            await _context.Post.InsertOneAsync(post);
            return post;
        }

        async Task<bool> IPostReposetory.DeletePost(string id)
        {
            var deletedPost = await _context.Post.DeleteOneAsync(p => p.PostId == id);
            return deletedPost.IsAcknowledged & deletedPost.DeletedCount > 0;
        }

        async Task<bool> IPostReposetory.UpdateProduct(Domain.Entities.Post post)
        {
            var updatedPost = await _context
                .Post
                .ReplaceOneAsync(p => p.PostId == post.PostId, post);
            return updatedPost.IsAcknowledged && updatedPost.ModifiedCount > 0;
        }


    }
}
