using AutoMapper;
using MediatR;
using Post.Application.Mappers;
using Post.Application.Queries;
using Post.Application.Responses;
using Post.Domain.Repositories;

namespace Post.Application.Handles
{
    public class GetPostHandler(IPostRepository postRepository, IMapper mapper) : IRequestHandler<GetPostQuery, IList<GetPostResponse>>
    {
        private readonly IPostRepository _postRepository = postRepository;

        public async Task<IList<GetPostResponse>> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var postList = await _postRepository.GetPost();
            var postResponseList = PostMapper.Mapper.Map<IList<Domain.Entities.Post>, IList<GetPostResponse>>(postList.ToList());
            return postResponseList;
        }

    }
}
