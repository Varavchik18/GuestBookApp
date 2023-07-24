using MediatR;
using Microsoft.EntityFrameworkCore;

public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, int>
{
    private readonly AppDbContext _context;

    public UpdateNoteCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await _context.Notes.SingleAsync(x => x.IdNote == request.IdNote);

        if(note is null || request.IdNote == 0)
        {
            throw new NotFoundException("Note not found");
        }

        if (request.Title == null || String.IsNullOrWhiteSpace(request.Title))
        {
            throw new BadRequestException("Title is required");
        }

        if (request.Description == null || String.IsNullOrWhiteSpace(request.Description))
        {
            throw new BadRequestException("Description is required");
        }

        note.Update(request.Title, request.Description, request.DateTimeUpdated);
        await _context.SaveToDbAsync();

        return note.IdNote;
    }
}
