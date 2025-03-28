using FileManager.Application.Commands;
using FileManager.Application.Mappers;
using FileManager.Application.Responses;
using FileManager.Domain.Entities.DTO;
using FileManager.Domain.Reposetories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FileManager.Application.Handlers
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, FileManagerResponse>
    {
        private IFileManagerReposetory _iFileManagerRepository;
        public CreateFileCommandHandler(IFileManagerReposetory fileManagerReposetory)
        {
            _iFileManagerRepository = fileManagerReposetory;
        }

        public async Task<FileManagerResponse> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {

            var fileeUrl = await _iFileManagerRepository.SaveFileAsync(request.FileUrl);
            return new FileManagerResponse{FileUrl = fileeUrl};
        }


    }
}
