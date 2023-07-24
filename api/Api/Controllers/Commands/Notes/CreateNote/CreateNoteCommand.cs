
using MediatR;
namespace Api.Controllers.Commands.Notes;

public class CreateNoteCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset DateTimeCreated { get => DateTimeOffset.Now; }
    public DateTimeOffset DateTimeUpdated { get => DateTimeOffset.Now; }
    public int AuthorId { get; set; }
}