using AutoMapper;
using Domain.Models;
using MediatR;
namespace Api.Controllers.Queries.Notes;

public class GetNoteByIdRequestHandler : IRequestHandler<GetNoteByIdRequest, GetNoteByIdResponse>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetNoteByIdRequestHandler(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetNoteByIdResponse> Handle(GetNoteByIdRequest request, CancellationToken cancellationToken)
    {
        var note = await _context.FindAsync<Note>(request.IdNote);

        if (note == null || request.IdNote == 0)
        {
            throw new NotFoundException(nameof(Note), request.IdNote);
        }

        return _mapper.Map<GetNoteByIdResponse>(note);
    }
}