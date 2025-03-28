using AutoMapper;
using Stories.Application.Commands;
using Stories.Application.Queries;
using Stories.Application.Responses;
using Stories.Domain.Entity;
using Stories.Domain.Entity.DTO;

namespace Stories.Application.Mappers
{
    public class StoryMappingProfile : Profile
    {
        public StoryMappingProfile()
        {
            CreateMap<ShortsDTO, CreateStoryCommand>().ReverseMap();
            CreateMap<string, GetStoryByCreatorQuery>().ReverseMap();
            CreateMap<Short, GetStoryResponse>().ReverseMap();
            CreateMap<Short, GetStoryByIdResponse>().ReverseMap();
        }

    }
}
