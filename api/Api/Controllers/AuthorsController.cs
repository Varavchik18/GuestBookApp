using Api.Controllers.Commands.Authors;
using Api.Controllers.Queries.Authors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Queries

    [HttpGet("list")]
    public async Task<IActionResult> GetAuthors([FromQuery] GetAuthorsRequest query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{idAuthor}")]
    public async Task<IActionResult> GetAuthorById([FromRoute] int idAuthor)
    {
        try
        {
            var query = new GetAuthorByIdRequest()
            {
                IdAuthor = idAuthor
            };
            query.IdAuthor = idAuthor;
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    #endregion

    #region Commands

    [HttpPost("create")]
    public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{idAuthor}/update")]
    public async Task<IActionResult> UpdateAuthor(int idAuthor, UpdateAuthorCommand command)
    {
        try
        {
            command.IdAuthor = idAuthor;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (BadRequestException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{idAuthor}/delete")]
    public async Task<IActionResult> DeleteAuthor(int idAuthor, [FromBody] DeleteAuthorCommand command)
    {
        try
        {
            command.IdAuthor = idAuthor;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    #endregion
}
