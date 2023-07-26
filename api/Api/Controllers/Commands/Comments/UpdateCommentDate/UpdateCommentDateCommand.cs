
using MediatR;
namespace Api.Controllers.Commands.Comments;

public class UpdateCommentDateCommand : IRequest<int>
{
    protected internal int IdComment { get; set; }
    public DateTimeOffset DateTimeCreated { get; set;}
    public DateTimeOffset DateTimeUpdated {get => DateTimeOffset.Now;}
}