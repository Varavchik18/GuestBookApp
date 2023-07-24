using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetNotesRequestHandler : IRequestHandler<GetNotesRequest, List<GetNotesResponse>>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetNotesRequestHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public Task<List<GetNotesResponse>> Handle(GetNotesRequest request, CancellationToken cancellationToken)
    {
        var notes = _dbContext.Notes
            .Include(x => x.Author)
            .ToList();

        var response = _mapper.Map<List<GetNotesResponse>>(notes);

        return Task.FromResult(response);
    }
}
