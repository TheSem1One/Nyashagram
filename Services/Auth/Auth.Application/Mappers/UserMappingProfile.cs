using Auth.Application.Responses;
using Auth.Domain.Entities;
using AutoMapper;

namespace Auth.Application.Mappers
{
    public class UserMappingProfile :Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
        }
    }
}
