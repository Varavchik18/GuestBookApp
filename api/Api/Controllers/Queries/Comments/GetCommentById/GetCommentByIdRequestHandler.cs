using AutoMapper;
using Domain.Models;
using MediatR;
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
        var comment = await _context.FindAsync<Comment>(request.IdComment);

        if (comment == null || request.IdComment == 0)
        {
            throw new NotFoundException(nameof(Comment), request.IdComment);
        }

        return _mapper.Map<GetCommentByIdResponse>(comment);
    }
}