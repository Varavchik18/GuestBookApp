using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers.Commands.Comments;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, int>
{
    private readonly AppDbContext _context;

    public UpdateCommentCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments.SingleOrDefaultAsync(x => x.IdComment == request.IdComment);

        if (comment is null || request.IdComment == 0)
        {
            throw new NotFoundException(nameof(Comment), request.IdComment);
        }
        ValidateFields(request.Title, request.Description);

        comment.Update(request.Title, request.Description, request.DateTimeUpdated);
        await _context.SaveToDbAsync();

        return comment.IdComment;
    }



    private void ValidateFields(string title, string description)
    {
        ValidateTitle(title);
        ValidateDescription(description);
    }

    private void ValidateTitle(string title)
    {
        if (title is null || String.IsNullOrWhiteSpace(title))
        {
            throw new BadRequestException("Title is required");
        }
        if (title.Length > 50)
        {
            throw new BadRequestException("Title must be less than 50 characters");
        }
    }

    private void ValidateDescription(string description)
    {
        if (description is null || String.IsNullOrWhiteSpace(description))
        {
            throw new BadRequestException("Description is required");
        }
        if (description.Length > 100)
        {
            throw new BadRequestException("Description must be less than 100 characters");
        }
    }
}
