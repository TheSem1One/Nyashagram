using MediatR;
using Stories.Application.Responses;

namespace Stories.Application.Commands
{
    public class CreateStoryCommand : IRequest<CreateStoryResponse>
    {
        public string ImageUrl { get; set; } = null!;
        public string NickName { get; set; } = null!;
    }
}
