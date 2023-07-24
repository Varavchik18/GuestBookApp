using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAuthorByIdRequestHandler : IRequestHandler<GetAuthorByIdRequest, GetAuthorByIdResponse>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetAuthorByIdRequestHandler(AppDbContext appDbContext, IMapper mapper)
    {
        _context = appDbContext;
        _mapper = mapper;
    }

    public async Task<GetAuthorByIdResponse> Handle(GetAuthorByIdRequest request, CancellationToken cancellationToken)
    {
        var author = await _context.Authors.SingleAsync(x => x.IdAuthor == request.IdAuthor);
        if (author == null || author.IdAuthor == 0)
        {
            throw new NotFoundException(nameof(Author), request.IdAuthor);
        }
        return _mapper.Map<GetAuthorByIdResponse>(author);
    }
}