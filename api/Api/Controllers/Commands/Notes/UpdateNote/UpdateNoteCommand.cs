
using MediatR;
namespace Api.Controllers.Commands.Notes;

public class UpdateNoteCommand : IRequest<int>
{
    public int IdNote { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset DateTimeUpdated { get => DateTimeOffset.Now; }
}