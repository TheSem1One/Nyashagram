﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stories.Application.Commands;
using Stories.Application.Queries;
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
                StoriesImageUrl = shortDto.StoryImageUrl,
                CreatorNickName = shortDto.CreatorNickName
            });
            return Ok(result);
        }


        [HttpGet("{nickName}/stories")]
        public async Task<ActionResult<IList<GetStoryByCreatorQuery>>> GetStoryByCreator([FromRoute] string nickName)
        {
            var query = new GetStoryByCreatorQuery { NickName = nickName };
            var result = await _mediator.Send(query);
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
