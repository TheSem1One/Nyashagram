using AutoMapper;
using MediatR;
using Post.Application.Commands;
using Post.Application.Mappers;
using Post.Application.Responses;
using Post.Domain.Entities.DTO;
using Post.Domain.Reposetories;

namespace Post.Application.Handles
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, CreatePostResponse>
    {
        private readonly IPostReposetory _postReposetory;
        public CreatePostHandler(IPostReposetory postReposetory, IMapper mapper)
        {
            _postReposetory = postReposetory;
        }

        public async Task<CreatePostResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var map = PostMapper.Mapper.Map<CreatePostCommand, PostDTO>(request);
            var creatingPost = await _postReposetory.CreatePost(map);
            return new CreatePostResponse { PostId = creatingPost };
        }
    }
}
