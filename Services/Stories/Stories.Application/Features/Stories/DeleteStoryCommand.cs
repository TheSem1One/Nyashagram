﻿using MediatR;
using Stories.Application.Responses;
using Stories.Domain.Repositories;
namespace Stories.Application.Features.Stories
{
    public class DeleteStoryCommand : IRequest<DeleteStoryResponse>
    {
        public string StoryId { get; set; } = null!;
    }

    class DeleteStoryHandler(IStoriesRepository storiesRepository) : IRequestHandler<DeleteStoryCommand, DeleteStoryResponse>
    {
        private readonly IStoriesRepository _storiesRepository = storiesRepository;

        public async Task<DeleteStoryResponse> Handle(DeleteStoryCommand request, CancellationToken cancellationToken)
        {
            var delete = await _storiesRepository.DeleteStory(request.StoryId);
            return new DeleteStoryResponse { Status = delete };
        }
    }
}
