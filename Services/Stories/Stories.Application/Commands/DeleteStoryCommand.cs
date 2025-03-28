using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Stories.Application.Responses;

namespace Stories.Application.Commands
{
    public class DeleteStoryCommand : IRequest<DeleteStoryResponse>
    {
        public string StoryId { get; set; }
    }
}
