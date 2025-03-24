using AutoMapper;
using MediatR;
using Post.Application.Mappers;
using Post.Application.Queries;
using Post.Application.Responses;
using Post.Domain.Reposetories;

namespace Post.Application.Handles
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, GetPostByIdResponse>
    {

        private readonly IPostReposetory _postReposetory;
        public GetPostByIdHandler(IPostReposetory postReposetory, IMapper mapper)
        {
            _postReposetory = postReposetory;
        }
        public async Task<GetPostByIdResponse> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _postReposetory.GetPostById(request.PostId);
            var postResponse = PostMapper.Mapper.Map<Domain.Entities.Post, GetPostByIdResponse>(post);
            return postResponse;
        }
    }
}
