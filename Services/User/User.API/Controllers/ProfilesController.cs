using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Post;
using User.Application.Features.Profile;
using User.Application.Features.Story;
using User.Domain.DTO.Profile;

namespace User.API.Controllers
{
    public class ProfilesController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{nickName}")]
        public async Task<ActionResult<ProfileDto>> GetProfile([FromRoute] string nickName)
        {
            var query = new GetProfileQuery { NickName = nickName };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPatch]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPatch]
        public async Task<ActionResult<bool>> AddToFavorite([FromBody] AddToFavoriteCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpPatch("addPost")]
        public async Task<ActionResult<bool>> AddPost([FromBody] AddPostCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPatch("deletePost")]
        public async Task<ActionResult<bool>> DeletePost([FromBody] DeletePostCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPatch("AddStory")]
        public async Task<ActionResult<bool>> AddStory([FromBody] AddStoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPatch("deleteStory")]
        public async Task<ActionResult<bool>> DeleteStory([FromBody] DeleteStoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
