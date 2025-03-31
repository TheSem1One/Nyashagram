using FileManager.Application.Commands;
using FileManager.Application.Responses;
using FileManager.Domain.Reposetories;
using MediatR;

namespace FileManager.Application.Handlers
{
    public class CreateFileCommandHandler(IFileManagerReposetory fileManagerRepository) : IRequestHandler<CreateFileCommand, FileManagerResponse>
    {
        private readonly IFileManagerReposetory _iFileManagerRepository = fileManagerRepository;

        public async Task<FileManagerResponse> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {

            var fileUrl = await _iFileManagerRepository.SaveFileAsync(request.FileUrl);
            return new FileManagerResponse { FileUrl = fileUrl };
        }


    }
}
