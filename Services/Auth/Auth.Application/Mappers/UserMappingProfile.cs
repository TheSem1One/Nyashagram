using Auth.Application.Commands;
using Auth.Application.Responses;
using Auth.Domain.DTO;
using Auth.Domain.Entities;
using AutoMapper;

namespace Auth.Application.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<CreateUserCommand, RegisterDTO>().ReverseMap();
            CreateMap<LoginUserCommand, LoginDTO>().ReverseMap();
        }
    }
}
