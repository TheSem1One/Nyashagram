using FileManager.Application.Commands;
using FileManager.Application.Mappers;
using FileManager.Application.Responses;
using FileManager.Domain.Reposetories;
using MediatR;

namespace FileManager.Application.Handlers
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, FileManagerResponse>
    {
        private IFileManagerReposetory _iFileManagerReposetory;
        public CreateFileCommandHandler(IFileManagerReposetory fileManagerReposetory)
        {
            _iFileManagerReposetory = fileManagerReposetory;
        }

        public Task<FileManagerResponse> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var userEntity = FileManagerMapper.Mapper.Map<FileDTO>(request);
            if (userEntity is null)
            {
                throw new ApplicationException("There is an issue with mapping while creating new User");
            }
            var authToken = await _iuser.CreateUser(userEntity);
            return new AuthResponse { Token = authToken };
        }
    }
}
