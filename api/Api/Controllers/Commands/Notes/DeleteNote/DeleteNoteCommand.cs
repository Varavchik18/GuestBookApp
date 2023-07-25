using MediatR;
namespace Api.Controllers.Commands.Notes;

public class DeleteNoteCommand : IRequest<int>
{
    protected internal int IdNote { get; set; }
}