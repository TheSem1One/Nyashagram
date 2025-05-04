using MediatR;
using Post.Application.Mappers;
using Post.Domain.Entities.DTO;
using Post.Domain.Repositories;

namespace Post.Application.Features.Post
{
    public class LikeCommand : IRequest<bool>
    {
        public string PostId { get; set; } = null!;
        public string NickName { get; set; } = null!;
    }

    public class LikeHandler(IPostRepository post) : IRequestHandler<LikeCommand,bool>
    {
        private readonly IPostRepository _post = post;
        public async Task<bool> Handle(LikeCommand request, CancellationToken cancellationToken)
        {
            var req = PostMapper.Mapper.Map<LikeDto>(request);
            return await _post.Like(req);
        }
    }
}
