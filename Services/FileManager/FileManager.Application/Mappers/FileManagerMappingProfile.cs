using AutoMapper;
using FileManager.Application.Responses;
using FileManager.Domain.Entities;
using FileManager.Domain.Entities.DTO;

namespace FileManager.Application.Mappers
{
    public class FileManagerMappingProfile : Profile
    {
        public FileManagerMappingProfile()
        {
            CreateMap<Image, FileManagerResponse>().ReverseMap();
            CreateMap(FileDTO,)
        }
    }
}
