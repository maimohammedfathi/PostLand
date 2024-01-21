using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostLandApplication.Features.Posts.Commands.CreatePost;
using PostLandApplication.Features.Posts.Commands.DeletePost;
using PostLandApplication.Features.Posts.Commands.UpdatePost;
using PostLandApplication.Features.Posts.Queries.GetPostDetails;
using PostLandApplication.Features.Posts.Queries.GetPostList;

namespace PostLandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("All", Name = "GetAllPosts")]
        public async Task<ActionResult<List<GetPostListViewModel>>> GetAllPosts()
        {
            return await _mediator.Send(new GetPostListQuery());
        }

        [HttpPost("{id}", Name = "GetPostById")]
        public async Task<ActionResult<GetPostDetialViewModel>> GetPostById(Guid Id)
        {
            var getEventDetailQuery = new GetPostDetailsQuery() { PostId = Id };
            return await _mediator.Send(getEventDetailQuery);
        }

        [HttpPost(Name = "AddPost")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePostCommand createPostCommand)
        {
            Guid id = await _mediator.Send(createPostCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdatePost")]
        public async Task<ActionResult> Update([FromBody] UpdatePostCommand updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePostCommand = new DeletePostCommand() { PostId = id };
            await _mediator.Send(deletePostCommand);
            return NoContent();
        }

    }
}
