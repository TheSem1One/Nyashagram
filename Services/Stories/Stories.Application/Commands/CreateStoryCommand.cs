using MediatR;
using Stories.Application.Responses;

namespace Stories.Application.Commands
{
    public class CreateStoryCommand : IRequest<CreateStoryResponse>
    {
    }
}
