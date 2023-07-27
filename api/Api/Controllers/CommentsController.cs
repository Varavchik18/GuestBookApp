using Microsoft.AspNetCore.Mvc;
using MediatR;
using Api.Controllers.Queries.Comments;
using Api.Controllers.Commands.Comments;
using Microsoft.AspNetCore.Cors;

namespace YourApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("GuestBookUI")]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetComments([FromQuery] GetCommentsRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            try
            {
                var request = new GetCommentByIdRequest() { IdComment = id };
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentCommand command)
        {
            try
            {
                command.IdComment = id;
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/updateDate")]
        public async Task<IActionResult> UpdateCommentDate([FromRoute] int id, [FromBody] UpdateCommentDateCommand command)
        {
            try
            {
                command.IdComment = id;
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            try
            {
                var command = new DeleteCommentCommand { IdComment = id };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
