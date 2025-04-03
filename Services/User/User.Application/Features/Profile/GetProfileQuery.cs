using MediatR;
using User.Application.Mappers;
using User.Domain.DTO;
using User.Domain.DTO.Profile;
using User.Domain.Repositories;

namespace User.Application.Features.Profile
{
    public class GetProfileQuery : IRequest<ProfileDto>
    {
        public string NickName { get; set; } = null!;
    }

    public class GetProfileHandler(IProfile profile) : IRequestHandler<GetProfileQuery, ProfileDto>
    {
        private readonly IProfile _profile = profile;
        public async Task<ProfileDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _profile.GetProfile(request.NickName);
            return UserMapper.Mapper.Map<ProfileDto>(user);
        }
    }
}
