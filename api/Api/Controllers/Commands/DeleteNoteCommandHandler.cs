using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, int>
{
    private readonly AppDbContext _context;

    public DeleteNoteCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var note = await _context.Notes.SingleAsync(x => x.IdNote == request.IdNote);
        if (note is null || request.IdNote == 0)
        {
            throw new NotFoundException("Note not found");
        }
        
        _context.Notes.Remove(note);

        await _context.SaveToDbAsync();
        return note.IdNote;
    }
}
