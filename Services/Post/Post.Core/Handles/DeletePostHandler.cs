using AutoMapper;
using MediatR;
using Post.Application.Commands;
using Post.Application.Responses;
using Post.Domain.Repositories;

namespace Post.Application.Handles
{
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
