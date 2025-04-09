using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stories.Application.Features.Stories;
using Stories.Application.Responses;
using Stories.Domain.Entity.DTO;

namespace Stories.API.Controllers
{
    public class StoriesController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<CreateStoryResponse>> CreateStory([FromBody] ShortsDTO shortDto)
        {
            var result = await _mediator.Send(new CreateStoryCommand()
            {
                StoryImageUrl = shortDto.StoryImageUrl,
                CreatorNickName = shortDto.CreatorNickName
            });
            return Ok(result);
        }


      

        [HttpGet("{id}")]

        public async Task<ActionResult<GetStoryByIdResponse>> GetPostById([FromRoute] string id)
        {
            var query = new GetStoryByIdQuery { StoryId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteStoryResponse>> DeletePost([FromBody] string id)
        {
            var query = new DeleteStoryCommand() { StoryId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
