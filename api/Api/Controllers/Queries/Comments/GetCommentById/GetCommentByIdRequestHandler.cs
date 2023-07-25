using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.Queries.Comments;

public class GetCommentByIdRequestHandler : IRequestHandler<GetCommentByIdRequest, GetCommentByIdResponse>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetCommentByIdRequestHandler(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetCommentByIdResponse> Handle(GetCommentByIdRequest request, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments
            .Include(c => c.Author)
            .SingleOrDefaultAsync(c => c.IdComment == request.IdComment);

        if (comment == null || request.IdComment == 0)
        {
            throw new NotFoundException(nameof(Comment), request.IdComment);
        }

        return _mapper.Map<GetCommentByIdResponse>(comment);
    }
}