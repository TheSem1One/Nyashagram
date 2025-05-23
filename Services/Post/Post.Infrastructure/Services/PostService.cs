﻿using MongoDB.Driver;
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

        public async Task<bool> AddComments(CommentsDto comments)
        {
            var filter = Builders<Domain.Entities.Post>.Filter.Eq(p => p.PostId, comments.PostId);
            var newComment = new Comment
            {
                ComentatorNickName = comments.NickName,
                Notes = comments.Description
            };
            var update = Builders<Domain.Entities.Post>.Update.Push(p => p.Comments, newComment);
            var result = await _context.Post.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteComments(CommentsDto comments)
        {
            var filter = Builders<Domain.Entities.Post>.Filter.Eq(p => p.PostId, comments.PostId);
            var commentToRemove = Builders<Domain.Entities.Post>.Filter.ElemMatch(
                p => p.Comments,
                c => c.ComentatorNickName == comments.NickName && c.Notes == comments.Description);
            var update = Builders<Domain.Entities.Post>.Update.PullFilter(p => p.Comments,
                c => c.ComentatorNickName == comments.NickName && c.Notes == comments.Description);
            var result = await _context.Post.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }

        public async Task<bool> Like(LikeDto dto)
        {
            var postFilter = Builders<Domain.Entities.Post>.Filter.Eq(p => p.PostId, dto.PostId);
            var existingPost = await _context.Post.Find(postFilter).FirstOrDefaultAsync();
            if (existingPost.Likes.LikesNickName.Contains(dto.NickName))
            {
                var update = Builders<Domain.Entities.Post>.Update
                    .Inc(p => p.Likes.CountLike, -1)
                    .Pull(p => p.Likes.LikesNickName, dto.NickName);
                var result = await _context.Post.UpdateOneAsync(postFilter, update);
                return result.ModifiedCount > 0;
            }
            else
            {
                var update = Builders<Domain.Entities.Post>.Update
                    .Inc(p => p.Likes.CountLike, 1)
                    .Push(p => p.Likes.LikesNickName, dto.NickName);
                var result = await _context.Post.UpdateOneAsync(postFilter, update);
                return result.ModifiedCount > 0;
            }
        }

    }

}

