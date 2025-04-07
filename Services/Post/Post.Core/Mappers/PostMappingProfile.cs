using AutoMapper;
using Post.Application.Features.Post;
using Post.Application.Responses;
using Post.Domain.Entities;
using Post.Domain.Entities.DTO;

namespace Post.Application.Mappers
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Domain.Entities.Post, GetPostResponse>().ReverseMap();
            CreateMap<Domain.Entities.Post, GetPostByIdResponse>().ReverseMap();
            CreateMap<CreatePostCommand, PostDto>().ReverseMap();
            CreateMap<LikeCommand, LikeDto>().ReverseMap();
            CreateMap<DeleteCommentsCommand, CommentsDto>().ReverseMap();
            CreateMap<CreateCommentsCommand, CommentsDto>().ReverseMap();

        }
    }
}
