﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Post.Application.Commands;
using Post.Application.Queries;
using Post.Application.Responses;
using Post.Domain.Entities.DTO;

namespace Post.API.Controllers
{
    public class PostController : ApiController
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreatePost")]
        [ProducesResponseType(typeof(CreatePostResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreatePostResponse>> CreatePost([FromBody] PostDTO postDto)
        {
            var result = await _mediator.Send(new CreatePostCommand(){Description = postDto.Description,ImageUrl = postDto.ImageUrl,NickName = postDto.NickName});
            return Ok(result);
        }


        [HttpGet]
        [Route("[action]/{NickName}", Name = "GetPostByCreator")]
        [ProducesResponseType(typeof(GetPostByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<GetPostResponse>>> GetPostByCreator(string NickName)
        {
            var query = new GetPostByCreatorQuery { NickName = NickName };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetPost")]
        [ProducesResponseType(typeof(GetPostResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<GetPostResponse>>> GetPost()
        {
            var query = new GetPostQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet]
        [Route("[action]/{Id}", Name = "GetPostById")]
        [ProducesResponseType(typeof(GetPostByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]

        public async Task<ActionResult<GetPostByIdResponse>> GetPostById(string Id)
        {
            var query = new GetPostByIdQuery { PostId = Id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeletePost")]
        [ProducesResponseType(typeof(DeletePostResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<DeletePostResponse>> DeletePost([FromBody]string Id)
        {
            var query = new DeletePostCommand() { PostId = Id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
