using MediatR;
using Post.Application.Mappers;
using Post.Domain.Entities.DTO;
using Post.Domain.Repositories;

namespace Post.Application.Features.Post
{
    public class DeleteCommentsCommand : IRequest<bool>
    {
        public string PostId { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string NickName { get; set; } = null!;
    }

    public class DeleteCommentsHandler(IPostRepository post) : IRequestHandler<DeleteCommentsCommand, bool>
    {
        private readonly IPostRepository _post = post;
        public async Task<bool> Handle(DeleteCommentsCommand request, CancellationToken cancellationToken)
        {
            var req = PostMapper.Mapper.Map<CommentsDto>(request);
            return await _post.DeleteComments(req);
        }
    }
}
