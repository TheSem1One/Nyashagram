using MediatR;
using User.Application.Mappers;
using User.Domain.DTO;
using User.Domain.Repositories;

namespace User.Application.Features.Profile
{
    public class UpdateProfileCommand : IRequest<bool>
    {
        public string NickName { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? BirthDate { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateProfileHandler(IProfile profile) : IRequestHandler<UpdateProfileCommand, bool>
    {
        private readonly IProfile _profile = profile;
        public async Task<bool> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var user = UserMapper.Mapper.Map<UpdateProfileCommand, ProfileDto>(request);
            return await _profile.UpdateProfile(user);
        }
    }
}
