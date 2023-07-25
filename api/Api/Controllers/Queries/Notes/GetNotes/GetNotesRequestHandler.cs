using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers.Queries.Notes;
//? nested query to retrieve sub-object of Author or at least its Id
public class GetNotesRequestHandler : IRequestHandler<GetNotesRequest, List<GetNotesResponse>>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetNotesRequestHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<GetNotesResponse>> Handle(GetNotesRequest request, CancellationToken cancellationToken)
    {
        var notes = await _dbContext.Notes
            .Include(n => n.Author)
            .ToListAsync();

        var response = _mapper.Map<List<GetNotesResponse>>(notes);

        return response;
    }
}
