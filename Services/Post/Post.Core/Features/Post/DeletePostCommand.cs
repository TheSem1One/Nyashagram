using AutoMapper;
using MediatR;
using Post.Application.Responses;
using Post.Domain.Repositories;

namespace Post.Application.Features.Post
{
    public class DeletePostCommand : IRequest<DeletePostResponse>
    {
        public string PostId { get; set; } = null!;
    }

    public class DeletePostHandler(IPostRepository postRepository, IMapper mapper) : IRequestHandler<DeletePostCommand, DeletePostResponse>
    {
        private readonly IPostRepository _postRepository = postRepository;

        public async Task<DeletePostResponse> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var delete = await _postRepository.DeletePost(request.PostId);
            return new DeletePostResponse { Status = delete };
        }
    }
}
