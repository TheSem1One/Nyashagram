using AutoMapper;
using MediatR;
using Post.Application.Mappers;
using Post.Application.Queries;
using Post.Application.Responses;
using Post.Domain.Entities;
using Post.Domain.Reposetories;

namespace Post.Application.Handles
{
    public class DeletePostHandler : IRequestHandler<DeletePostQuery, DeletePostResponse>
    {
        private readonly IPostReposetory _postReposetory;
        public DeletePostHandler(IPostReposetory postReposetory, IMapper mapper)
        {
            _postReposetory = postReposetory;
        }
        public async Task<DeletePostResponse> Handle(DeletePostQuery request, CancellationToken cancellationToken)
        {
            var delete = await _postReposetory.DeletePost(request.PostId);
            return new DeletePostResponse { Status = delete };
        }
    }
}
