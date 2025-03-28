using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Stories.Application.Commands;
using Stories.Application.Queries;
using Stories.Application.Responses;
using Stories.Domain.Entity.DTO;

namespace Stories.API.Controllers
{
    public class StoriesController : ApiController
    {
        private readonly IMediator _mediator;

        public StoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateStory")]
        [ProducesResponseType(typeof(CreateStoryResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateStoryResponse>> CreatePost([FromBody] ShortsDTO shortDto)
        {
            var result = await _mediator.Send(new CreateStoryCommand() {  StoriesImageUrl = shortDto.StoriesImageUrl, CreatorNickName = shortDto.CreatorNickName });
            return Ok(result);
        }


        [HttpGet]
        [Route("GetStoryByCreator")]
        [ProducesResponseType(typeof(GetStoryByCreatorQuery), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<GetStoryByCreatorQuery>>> GetPostByCreator([FromHeader] string nickName)
        {
            var query = new GetStoryByCreatorQuery { NickName = nickName };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{Id}", Name = "GetPostById")]
        [ProducesResponseType(typeof(GetStoryByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<GetStoryByIdResponse>> GetPostById(string Id)
        {
            var query = new GetStoryByIdQuery {StoryId = Id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeletePost")]
        [ProducesResponseType(typeof(DeleteStoryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<DeleteStoryResponse>> DeletePost([FromBody] string Id)
        {
            var query = new DeleteStoryCommand() { StoryId= Id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
