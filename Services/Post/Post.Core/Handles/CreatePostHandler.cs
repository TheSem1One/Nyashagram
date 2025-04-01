using MediatR;
using Post.Application.Commands;
using Post.Application.Mappers;
using Post.Application.Responses;
using Post.Domain.Entities.DTO;
using Post.Domain.Repositories;

namespace Post.Application.Handles
{
    public class CreatePostHandler(IPostRepository postRepository) : IRequestHandler<CreatePostCommand, CreatePostResponse>
    {
        private readonly IPostRepository _postRepository = postRepository;

        public async Task<CreatePostResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var map = PostMapper.Mapper.Map<CreatePostCommand, PostDto>(request);
            var creatingPost = await _postRepository.CreatePost(map);
            return new CreatePostResponse { PostId = creatingPost };
        }
    }
}
