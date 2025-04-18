﻿using AutoMapper;
using FileManager.Application.Features.FileManager;
using FileManager.Application.Responses;
using Microsoft.AspNetCore.Http;

namespace FileManager.Application.Mappers
{
    public class FileManagerMappingProfile : Profile
    {
        public FileManagerMappingProfile()
        {
            CreateMap<IFormFile, FileManagerResponse>().ReverseMap();
        }
    }
}
