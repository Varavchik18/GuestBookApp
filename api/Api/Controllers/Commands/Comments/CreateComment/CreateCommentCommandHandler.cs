using MediatR;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers.Commands.Comments;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
{
    private readonly AppDbContext _context;

    public CreateCommentCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var author = await _context.Authors.SingleOrDefaultAsync(x => x.IdAuthor == request.AuthorId);

        if (author == null || author.IdAuthor == 0)
        {
            throw new NotFoundException(nameof(Author), request.AuthorId);
        }

        ValidateFields(request.Title, request.Description);

        var comment = new Comment(request.Title, request.Description, request.DateTimeCreated, request.DateTimeUpdated, author, request.ImageUrl);
        _context.Comments.Add(comment);
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
        if (description.Length > 500)
        {
            throw new BadRequestException("Description must be less than 500 characters");
        }
    }
}