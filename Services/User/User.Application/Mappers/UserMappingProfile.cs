
using User.Application.Responses;
using User.Domain.DTO;
using AutoMapper;
using User.Application.Features.Auth;
using User.Application.Features.Post;
using User.Application.Features.Profile;
using User.Application.Features.Story;

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
            CreateMap<Domain.Entities.User, UserDto>().ReverseMap();
            CreateMap<SubscribeCommand, SubscribeDto>().ReverseMap();
            CreateMap<UnsubscribeCommand, SubscribeDto>().ReverseMap();
            CreateMap<AddPostCommand, PostDto>().ReverseMap();
            CreateMap<DeletePostCommand, PostDto>().ReverseMap();
            CreateMap<AddStoryCommand, StoryDto>().ReverseMap();
            CreateMap<DeleteStoryCommand, StoryDto>().ReverseMap();

        }
    }
}
