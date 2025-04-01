using FileManager.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FileManager.Application.Commands
{
    public class CreateFileCommand : IRequest<FileManagerResponse>
    {
        public IFormFile FileUrl { get; set; } = null!;


    }
}
