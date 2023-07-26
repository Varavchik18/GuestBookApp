
using MediatR;
namespace Api.Controllers.Commands.Comments;

public class CreateCommentCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset DateTimeCreated { get => DateTimeOffset.Now; }
    public DateTimeOffset DateTimeUpdated { get => DateTimeOffset.Now; }
    public string ImageUrl { get; set; }
    public int AuthorId { get; set; }
}