using MediatR;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers.Commands.Notes;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, int>
{
    private readonly AppDbContext _context;

    public CreateNoteCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var author = await _context.Authors.SingleAsync(x => x.IdAuthor == request.AuthorId);

        if (author == null || author.IdAuthor == 0)
        {
            throw new NotFoundException(nameof(Author), request.AuthorId);
        }

        ValidateFields(request.Title, request.Description);

        var note = new Note(request.Title, request.Description, request.DateTimeCreated, request.DateTimeUpdated, author);
        _context.Notes.Add(note);
        await _context.SaveToDbAsync();

        return note.IdNote;
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