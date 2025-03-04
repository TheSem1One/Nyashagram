using MediatR;
using Post.Application.Queries;
using Post.Application.Responses;
using Post.Domain.Reposetories;

namespace Post.Application.Handles
{
    public class GetAllPostHandler : IRequestHandler<GetAllPostQuerry, IList<PostResponse>>
    {
        private readonly IPostReposetory _postReposetory;
        public GetAllPostHandler(IPostReposetory postReposetory)
        {
            _postReposetory = postReposetory;
        }
        public Task<IList<PostResponse>> Handle(GetAllPostQuerry request, CancellationToken cancellationToken)
        {
            var postList = await _postReposetory.GetAllPost();
            var postResponseList 
        }
    }
}
