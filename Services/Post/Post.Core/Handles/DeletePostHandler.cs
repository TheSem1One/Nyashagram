using AutoMapper;
using MediatR;
using Post.Application.Commands;
using Post.Application.Mappers;
using Post.Application.Queries;
using Post.Application.Responses;
using Post.Domain.Entities;
using Post.Domain.Reposetories;

namespace Post.Application.Handles
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, DeletePostResponse>
    {
        private readonly IPostRepository _postReposetory;
        public DeletePostHandler(IPostRepository postReposetory, IMapper mapper)
        {
            _postReposetory = postReposetory;
        }

        public async Task<DeletePostResponse> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var delete = await _postReposetory.DeletePost(request.PostId);
            return new DeletePostResponse { Status = delete };
        }
    }
}
