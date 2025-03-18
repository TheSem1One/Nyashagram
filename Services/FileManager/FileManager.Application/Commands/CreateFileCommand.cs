using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Application.Responses;

namespace FileManager.Application.Commands
{
    public class CreateFileCommand : IRequest<FileManagerResponse>
    {
        public List<string> FileUrl { get; set; } = null!;

        public CreateFileCommand(List<string> fileUrl)
        {
            FileUrl = fileUrl;
        }
    }
}
