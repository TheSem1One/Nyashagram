using MongoDB.Driver;
using Post.Domain.Entities.DTO;
using Post.Domain.Reposetories;
using Post.Infrastructure.Presistence;

namespace Post.Infrastructure.Repositories
{
    public class PostRepositories : IPostRepository
    {
        private readonly IPostContext _context;
        PostRepositories(IPostContext context)
        {
            _context = context;
        }

        async Task<IEnumerable<Domain.Entities.Post>> IPostRepository.GetPost()
        {
            return await _context
                .Post
                .Find(post => true)
                .ToListAsync();
        }
        async Task<IEnumerable<Domain.Entities.Post>> IPostRepository.GetPostByNickName(string nickName)
        {
            return await _context.Post
                .Find(p => p.CreatorNickName.ToLower() == nickName.ToLower())
                .ToListAsync();
        }
        async Task<Domain.Entities.Post> IPostRepository.GetPostById(string id)
        {
            return await _context
                .Post
                .Find(post => post.PostId == id)
                .FirstOrDefaultAsync();
        }

        async Task<string> IPostRepository.CreatePost(PostDTO postDTO)
        {
            var post = new Domain.Entities.Post
            {
                CreatorNickName = postDTO.NickName,
                PostImageUrl = postDTO.ImageUrl,
                Descriptions = postDTO.Description,
                CreateDateTime = DateTime.Now
            };
            await _context.Post.InsertOneAsync(post);
            return post.PostId;
        }

        async Task<bool> IPostRepository.DeletePost(string id)
        {
            var deletedPost = await _context.Post.DeleteOneAsync(p => p.PostId == id);
            return deletedPost.IsAcknowledged & deletedPost.DeletedCount > 0;
        }

        


    }
}
