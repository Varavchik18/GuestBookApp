using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers.Commands.Notes;

public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, int>
{
    private readonly AppDbContext _context;

    public UpdateNoteCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await _context.Notes.SingleOrDefaultAsync(x => x.IdNote == request.IdNote);

        if (note is null || request.IdNote == 0)
        {
            throw new NotFoundException(nameof(Note), request.IdNote);
        }
        ValidateFields(request.Title, request.Description);

        note.Update(request.Title, request.Description, request.DateTimeUpdated);
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
