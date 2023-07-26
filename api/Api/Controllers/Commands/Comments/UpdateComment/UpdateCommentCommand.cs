
using MediatR;
namespace Api.Controllers.Commands.Comments;

public class UpdateCommentCommand : IRequest<int>
{
    protected internal int IdComment { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public DateTimeOffset DateTimeUpdated { get => DateTimeOffset.Now; }
}