using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers.Commands.Comments;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, int>
{
    private readonly AppDbContext _context;

    public DeleteCommentCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments.SingleOrDefaultAsync(x => x.IdComment == request.IdComment);
        if (comment is null || request.IdComment == 0)
        {
            throw new NotFoundException(nameof(Comment), request.IdComment);
        }

        _context.Comments.Remove(comment);

        await _context.SaveToDbAsync();
        return comment.IdComment;
    }
}
