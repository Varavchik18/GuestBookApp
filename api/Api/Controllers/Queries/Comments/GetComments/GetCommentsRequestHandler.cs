using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers.Queries.Comments;
public class GetCommentsRequestHandler : IRequestHandler<GetCommentsRequest, List<GetCommentsResponse>>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCommentsRequestHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<GetCommentsResponse>> Handle(GetCommentsRequest request, CancellationToken cancellationToken)
    {
        var comments = await _dbContext.Comments
            .Include(n => n.Author)
            .ToListAsync();

        var response = _mapper.Map<List<GetCommentsResponse>>(comments);

        return response;
    }
}
