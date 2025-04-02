
using User.Application.Responses;
using User.Domain.DTO;
using AutoMapper;
using User.Application.Features.Auth;
using User.Application.Features.Profile;

namespace User.Application.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Domain.Entities.User, UserResponse>().ReverseMap();
            CreateMap<CreateUserCommand, RegisterDto>().ReverseMap();
            CreateMap<LoginUserCommand, LoginDto>().ReverseMap();
            CreateMap<UpdateProfileCommand, ProfileDto>().ReverseMap();
        }
    }
}
