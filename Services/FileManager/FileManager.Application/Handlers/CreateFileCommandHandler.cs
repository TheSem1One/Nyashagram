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
        private IFileManagerReposetory _iFileManagerReposetory;
        public CreateFileCommandHandler(IFileManagerReposetory fileManagerReposetory)
        {
            _iFileManagerReposetory = fileManagerReposetory;
        }

        public async Task<FileManagerResponse> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var fileEntities = FileManagerMapper.Mapper.Map<FileDTO>(request);

            var imageUrls = await _iFileManagerReposetory.SaveFileAsync(fileEntities);
            return imageUrls;
        }


    }
}
