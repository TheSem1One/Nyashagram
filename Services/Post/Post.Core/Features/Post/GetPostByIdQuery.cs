using AutoMapper;
using MediatR;
using Post.Application.Mappers;
using Post.Application.Responses;
using Post.Domain.Repositories;

namespace Post.Application.Features.Post
{
    public class GetPostByIdQuery : IRequest<GetPostByIdResponse>
    {
        public string PostId { get; set; } = null!;
    }

    public class GetPostByIdHandler(IPostRepository postRepository, IMapper mapper) : IRequestHandler<GetPostByIdQuery, GetPostByIdResponse>
    {
        private readonly IPostRepository _postRepository = postRepository;

        public async Task<GetPostByIdResponse> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetPostById(request.PostId);
            var postResponse = PostMapper.Mapper.Map<Domain.Entities.Post, GetPostByIdResponse>(post);
            return postResponse;
        }
    }
}
