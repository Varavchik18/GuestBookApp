using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using Domain.Models;

namespace YourApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public NotesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET api/notes
        [HttpGet("notes")]
        public async Task<IActionResult> GetNotes([FromQuery] GetNotesRequest request)
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
        public async Task<IActionResult> GetNoteById([FromQuery] GetNoteByIdRequest request)
        {
            try{
            var result = await _mediator.Send(request);
            return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteCommand command)
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
        public async Task<IActionResult> UpdateNote(int id, [FromBody] UpdateNoteCommand command)
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

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteNote([FromBody] DeleteNoteCommand command)
        {
            try{
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
