using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Post.Application.Responses;

namespace Post.Application.Mappers
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Domain.Entities.Post, GetPostResponse>().ReverseMap();
        }
    }
}
