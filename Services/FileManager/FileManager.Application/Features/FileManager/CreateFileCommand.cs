using FileManager.Application.Responses;
using FileManager.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace FileManager.Application.Features.FileManager
{
    public class CreateFileCommand : IRequest<FileManagerResponse>
    {
        public IFormFile FileUrl { get; set; } = null!;
    }
    public class CreateFileCommandHandler(IFileManagerRepository fileManagerRepository) : IRequestHandler<CreateFileCommand, FileManagerResponse>
    {
        private readonly IFileManagerRepository _iFileManagerRepository = fileManagerRepository;

        public async Task<FileManagerResponse> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {

            var fileUrl = await _iFileManagerRepository.SaveFileAsync(request.FileUrl);
            return new FileManagerResponse { FileUrl = fileUrl };
        }
    }
}
