using MediatR;
using User.Application.Mappers;
using User.Domain.DTO.Profile;
using User.Domain.Repositories;

namespace User.Application.Features.Post
{
    public class AddToFavoriteCommand : IRequest<bool>
    {
        public string NickName { get; set; } = null!;
        public string PostId { get; set; } = null!;
    }

    public class AddToFavoriteHandler(IProfile profile) : IRequestHandler< AddToFavoriteCommand, bool>
    {
        private readonly IProfile _profile = profile;
        public async Task<bool> Handle(AddToFavoriteCommand request, CancellationToken cancellationToken)
        {
            var req = UserMapper.Mapper.Map<FavoritePost>(request);
            return await _profile.AddToFavorite(req);
        }
    }

}
