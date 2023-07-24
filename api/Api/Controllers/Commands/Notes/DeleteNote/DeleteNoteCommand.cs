using MediatR;
namespace Api.Controllers.Commands.Notes;

public class DeleteNoteCommand : IRequest<int>
{
    public int IdNote { get; set; }
}