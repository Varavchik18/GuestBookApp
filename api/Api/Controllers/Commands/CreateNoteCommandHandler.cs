using MediatR;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, int>
{
  private readonly AppDbContext _context;

  public CreateNoteCommandHandler(AppDbContext context)
  {
    _context = context;
  }

  public async Task<int> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
  {
    if (request.Title == null || String.IsNullOrWhiteSpace(request.Title))
    {
      throw new BadRequestException("Title is required");
    }

    if (request.Description == null || String.IsNullOrWhiteSpace(request.Description))
    {
      throw new BadRequestException("Description is required");
    }

    var author = await _context.Authors.SingleAsync(x => x.Id == request.AuthorId);
    
    if(author == null || author.Id == 0)
    {
        throw new NotFoundException("Author not found");
    }

    var note = new Note(request.Title, request.Description, request.DateTimeCreated, request.DateTimeUpdated, author);
    _context.Notes.Add(note);
    await _context.SaveToDbAsync();

    return note.IdNote;
  }
}