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

    [HttpGet]
    public async Task<IActionResult> GetAuthors([FromQuery] GetAuthorsRequest query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{idAuthor}")]
    public async Task<IActionResult> GetAuthorById(int idAuthor, [FromBody] GetAuthorByIdRequest query)
    {
        try
        {
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

    [HttpPut("update/{idAuthor}")]
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

    [HttpDelete("delete/{idAuthor}")]
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
