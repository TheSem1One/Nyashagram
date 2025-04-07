using MongoDB.Driver;
using Post.Domain.Entities;
using Post.Domain.Entities.DTO;
using Post.Domain.Repositories;
using Post.Infrastructure.Persistence;

namespace Post.Infrastructure.Services
{
    public class PostService(IPostContext context) : IPostRepository
    {
        private readonly IPostContext _context = context;

        public async Task<IEnumerable<Domain.Entities.Post>> GetPost()
        {
            return await _context
                .Post
                .Find(post => true)
                .ToListAsync();
        }
        public async Task<IEnumerable<Domain.Entities.Post>> GetPostByNickName(string nickName)
        {
            return await _context.Post
                .Find(p => p.CreatorNickName.ToLower() == nickName.ToLower())
                .ToListAsync();
        }
        public async Task<Domain.Entities.Post> GetPostById(string id)
        {
            return await _context
                .Post
                .Find(post => post.PostId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<string> CreatePost(PostDto postDto)
        {
            var post = new Domain.Entities.Post
            {
                CreatorNickName = postDto.NickName,
                ImageUrl = postDto.ImageUrl,
                Descriptions = postDto.Description,
                CreateDateTime = DateTime.Now
            };
            await _context.Post.InsertOneAsync(post);
            return post.PostId;
        }

        public async Task<bool> DeletePost(string id)
        {
            var deletedPost = await _context.Post.DeleteOneAsync(p => p.PostId == id);
            return deletedPost.IsAcknowledged & deletedPost.DeletedCount > 0;
        }

        public async Task<bool> Comments(CommentsDto comments)
        {
            var filter = Builders<Domain.Entities.Post>.Filter.Eq(p => p.PostId, comments.Id);
            var newComment = new Comment
            {
                ComentatorNickName = comments.NickName,
                Notes = comments.Description
            };
            var update = Builders<Domain.Entities.Post>.Update.Push(p => p.Comments, newComment);
            var result = await _context.Post.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

    }
}
