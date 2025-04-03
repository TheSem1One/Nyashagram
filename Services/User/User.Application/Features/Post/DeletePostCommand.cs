using MediatR;
using User.Application.Mappers;
using User.Domain.DTO;
using User.Domain.Repositories;

namespace User.Application.Features.Post
{
    public class DeletePostCommand : IRequest<bool>
    {
        public string CreatorNickName { get; set; } = null!;
        public string Id { get; set; } = null!;
    }
    public class DeletePostHandler(IProfile profile) : IRequestHandler<DeletePostCommand, bool>
    {
        private readonly IProfile _profile = profile;
        public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var req = UserMapper.Mapper.Map<PostDto>(request);
            return await _profile.DeletePost(req);
        }
    }
}
