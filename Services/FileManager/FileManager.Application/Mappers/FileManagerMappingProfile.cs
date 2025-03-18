using AutoMapper;
using FileManager.Application.Responses;
using FileManager.Domain.Entities;

namespace FileManager.Application.Mappers
{
    public class FileManagerMappingProfile : Profile
    {
        public FileManagerMappingProfile()
        {
            CreateMap<Image, FileManagerResponse>().ReverseMap();
        }
    }
}
