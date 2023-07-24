using AutoMapper;
using Domain.Models;
using MediatR;
namespace Api.Controllers.Commands.Authors;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, int>
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public DeleteAuthorCommandHandler(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<int> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = _context.Authors.SingleOrDefault(x => x.IdAuthor == request.IdAuthor);
        if (author == null)
        {
            throw new NotFoundException(nameof(Author), request.IdAuthor);
        }

        _context.Authors.Remove(author);
        await _context.SaveToDbAsync();
        return author.IdAuthor;
    }
}