using MediatR;
namespace Api.Controllers.Commands.Comments;

public class DeleteCommentCommand : IRequest<int>
{
    protected internal int IdComment { get; set; }
}