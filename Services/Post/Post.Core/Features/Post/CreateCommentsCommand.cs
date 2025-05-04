using MediatR;
using Post.Application.Mappers;
using Post.Domain.Entities.DTO;
using Post.Domain.Repositories;

namespace Post.Application.Features.Post
{
    public class CreateCommentsCommand : IRequest<bool>
    {
        public string PostId { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string NickName { get; set; } = null!;
    }

    public class CreateCommentsHandler(IPostRepository post) : IRequestHandler<CreateCommentsCommand,bool>
    {
        private readonly IPostRepository _post = post;
        public async Task<bool> Handle(CreateCommentsCommand request, CancellationToken cancellationToken)
        {
            var req = PostMapper.Mapper.Map<CommentsDto>(request);
            return await _post.AddComments(req);
        }
    }
}
