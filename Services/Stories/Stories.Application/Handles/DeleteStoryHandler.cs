using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Stories.Application.Commands;
using Stories.Application.Responses;
using Stories.Domain.Repositories;

namespace Stories.Application.Handles
{
    class DeleteStoryHandler : IRequestHandler<DeleteStoryCommand, DeleteStoryResponse>
    {
        private readonly IStoriesRepository _storiesRepository;

        public DeleteStoryHandler(IStoriesRepository storiesRepository)
        {
            _storiesRepository = storiesRepository;
        }
        public async Task<DeleteStoryResponse> Handle(DeleteStoryCommand request, CancellationToken cancellationToken)
        {
            var delete = await _storiesRepository.DeleteStories(request.StoryId);
            return new DeleteStoryResponse{ Status = delete };
        }
    }
}
