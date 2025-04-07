using MediatR;
using Post.Application.Mappers;
using Post.Application.Responses;
using Post.Domain.Entities.DTO;
using Post.Domain.Repositories;

namespace Post.Application.Features.Post
{
    public class CreatePostCommand : IRequest<CreatePostResponse>
    {
        public string ImageUrl { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public string Description { get; set; } = null!;

    }

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
