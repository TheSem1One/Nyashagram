using AutoMapper;
using MediatR;
using Post.Application.Mappers;
using Post.Application.Queries;
using Post.Application.Responses;
using Post.Domain.Repositories;

namespace Post.Application.Handles
{
    public class GetPostByCreatorHandler(IPostRepository postRepository, IMapper mapper) : IRequestHandler<GetPostByCreatorQuery, IList<GetPostResponse>>
    {
        private readonly IPostRepository _postRepository = postRepository;

        public async Task<IList<GetPostResponse>> Handle(GetPostByCreatorQuery request, CancellationToken cancellationToken)
        {
            var postList = await _postRepository.GetPostByNickName(request.NickName);
            var postResponseList = PostMapper.Mapper.Map<IList<Domain.Entities.Post>, IList<GetPostResponse>>(postList.ToList());
            return postResponseList;
        }
    }
}
