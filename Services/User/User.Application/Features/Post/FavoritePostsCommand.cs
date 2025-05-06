using MediatR;
using User.Application.Mappers;
using User.Domain.DTO.Profile;
using User.Domain.Repositories;

namespace User.Application.Features.Post
{
    public class FavoritePostsCommand : IRequest<bool>
    {
        public string NickName { get; set; } = null!;
        public string PostId { get; set; } = null!;
    }

    public class FavoritePostsHandler(IProfile profile) : IRequestHandler< FavoritePostsCommand, bool>
    {
        private readonly IProfile _profile = profile;
        public async Task<bool> Handle(FavoritePostsCommand request, CancellationToken cancellationToken)
        {
            var req = UserMapper.Mapper.Map<FavoritePost>(request);
            return await _profile.FavoritePosts(req);
        }
    }

}
