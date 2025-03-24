using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Post.Application.Commands;
using Post.Application.Responses;
using Post.Domain.Entities.DTO;

namespace Post.Application.Mappers
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Domain.Entities.Post, GetPostResponse>().ReverseMap();
            CreateMap<Domain.Entities.Post, GetPostByIdResponse>().ReverseMap();
            CreateMap<CreatePostCommand, PostDTO>().ReverseMap();
        }
    }
}
