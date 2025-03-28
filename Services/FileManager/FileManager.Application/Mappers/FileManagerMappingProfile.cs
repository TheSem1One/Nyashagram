using AutoMapper;
using FileManager.Application.Commands;
using FileManager.Application.Responses;
using FileManager.Domain.Entities.DTO;
using Microsoft.AspNetCore.Http;

namespace FileManager.Application.Mappers
{
    public class FileManagerMappingProfile : Profile
    {
        public FileManagerMappingProfile()
        {
            CreateMap<IFormFile, FileManagerResponse>().ReverseMap();
            CreateMap<FileDTO, CreateFileCommand>().ReverseMap();
        }
    }
}
