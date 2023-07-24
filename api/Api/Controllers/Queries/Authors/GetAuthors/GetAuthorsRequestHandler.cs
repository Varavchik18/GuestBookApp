using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers.Queries.Authors;

public class GetAuthorsRequestHandler : IRequestHandler<GetAuthorsRequest, List<GetAuthorsResponse>>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetAuthorsRequestHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetAuthorsResponse>> Handle(GetAuthorsRequest request, CancellationToken cancellationToken)
    {
        var authors = await _context.Authors.ToListAsync();
        return _mapper.Map<List<GetAuthorsResponse>>(authors);
    }
}