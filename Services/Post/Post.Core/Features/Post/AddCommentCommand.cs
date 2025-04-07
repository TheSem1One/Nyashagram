using MediatR;
using Post.Application.Mappers;
using Post.Domain.Entities.DTO;
using Post.Domain.Repositories;

namespace Post.Application.Features.Post
{
    public class AddCommentCommand : IRequest<bool>
    {
        public string Id { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Comments { get; set; }
    }

    public class AddCommentHandler(IPostRepository post) : IRequestHandler<AddCommentCommand, bool>
    {
        private readonly IPostRepository _post = post;
        public async Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var req = PostMapper.Mapper.Map<CommentsDto>(request);
            return await _post.Comments(req);

        }
    }
}
