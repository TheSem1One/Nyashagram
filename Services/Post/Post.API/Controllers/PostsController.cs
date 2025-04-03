using MediatR;
using Microsoft.AspNetCore.Mvc;
using Post.Application.Commands;
using Post.Application.Queries;
using Post.Application.Responses;
using Post.Domain.Entities.DTO;

namespace Post.API.Controllers
{
    public class PostsController(IMediator mediator) : ApiController
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<CreatePostResponse>> CreatePost([FromBody] PostDto postDto)
        {
            var result = await _mediator.Send(new CreatePostCommand(){Description = postDto.Description,ImageUrl = postDto.ImageUrl,NickName = postDto.NickName});
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IList<GetPostResponse>>> GetPost()
        {
            var query = new GetPostQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetPostByIdResponse>> GetPostById(string id)
        {
            var query = new GetPostByIdQuery { PostId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeletePostResponse>> DeletePost([FromRoute]string id)
        {
            var query = new DeletePostCommand() { PostId = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
