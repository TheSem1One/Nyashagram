
using User.Application.Responses;
using User.Domain.DTO;
using AutoMapper;
using User.Application.Features.Auth;
using User.Application.Features.Post;
using User.Application.Features.Profile;
using User.Application.Features.Story;
using User.Application.Features.Users;
using User.Domain.DTO.Auth;
using User.Domain.DTO.Profile;
using User.Domain.DTO.Users;

namespace User.Application.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Domain.Entities.User, UserResponse>().ReverseMap();
            CreateMap<CreateUserCommand, RegisterDto>().ReverseMap();
            CreateMap<LoginUserCommand, LoginDto>().ReverseMap();
            CreateMap<UpdateProfileCommand, UpdateProfileDto>().ReverseMap();
            CreateMap<Domain.Entities.User, ProfileDto>().ReverseMap();
            CreateMap<SubscribeCommand, SubscribeDto>().ReverseMap();
            CreateMap<UnsubscribeCommand, SubscribeDto>().ReverseMap();
            CreateMap<AddPostCommand, PostDto>().ReverseMap();
            CreateMap<DeletePostCommand, PostDto>().ReverseMap();
            CreateMap<AddStoryCommand, StoryDto>().ReverseMap();
            CreateMap<DeleteStoryCommand, StoryDto>().ReverseMap();
            CreateMap<GetUsersByNickNameQuery, ProfileDto>().ReverseMap();

        }
    }
}
