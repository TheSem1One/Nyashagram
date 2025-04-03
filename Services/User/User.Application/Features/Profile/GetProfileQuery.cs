using MediatR;
using User.Application.Mappers;
using User.Domain.DTO;
using User.Domain.Repositories;

namespace User.Application.Features.Profile
{
    public class GetProfileQuery : IRequest<UserDto>
    {
        public string NickName { get; set; } = null!;
    }

    public class GetProfileHandler(IProfile profile) : IRequestHandler<GetProfileQuery, UserDto>
    {
        private readonly IProfile _profile = profile;
        public async Task<UserDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _profile.GetProfile(request.NickName);
            return UserMapper.Mapper.Map<UserDto>(user);
        }
    }
}
