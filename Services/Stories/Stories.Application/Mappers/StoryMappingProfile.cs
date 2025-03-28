using AutoMapper;
using Stories.Application.Commands;
using Stories.Application.Queries;
using Stories.Domain.Entity.DTO;

namespace Stories.Application.Mappers
{
    public class StoryMappingProfile : Profile
    {
        public StoryMappingProfile()
        {
            CreateMap<ShortsDTO, CreateStoryCommand>().ReverseMap();
            CreateMap<string, GetStoryByCreatorQuery>().ReverseMap();
        }
        
    }
}
