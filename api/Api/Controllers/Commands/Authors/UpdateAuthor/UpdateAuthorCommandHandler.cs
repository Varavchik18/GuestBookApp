using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers.Commands.Authors;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, int>
{
    private readonly AppDbContext _context;

    public UpdateAuthorCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _context.Authors.SingleOrDefaultAsync(x => x.IdAuthor == request.IdAuthor);

        if (author is null || author.IdAuthor == 0)
        {
            throw new NotFoundException(nameof(Author), request.IdAuthor);
        }

        Validate(request.FirstName, request.LastName, request.Phone, request.Email);

        author.Update(firstName: request.FirstName, lastName: request.LastName, phone: request.Phone, email: request.Email);
        _context.Authors.Update(author);
        await _context.SaveToDbAsync();

        return author.IdAuthor;
    }

    private void Validate(string firstName, string lastName, string phone, string email)
    {
        ValidateFirstName(firstName);
        ValidateLastName(lastName);
        ValidateEmail(email);
    }

    private void ValidateFirstName(string firstName)
    {
        if (firstName is null || String.IsNullOrWhiteSpace(firstName))
        {
            throw new BadRequestException("First name is required");
        }
        if (firstName.Length > 50)
        {
            throw new BadRequestException("First name must be less than 50 characters");
        }
    }

    private void ValidateLastName(string lastName)
    {
        if (lastName is null || String.IsNullOrWhiteSpace(lastName))
        {
            throw new BadRequestException("Last name is required");
        }
        if (lastName.Length > 50)
        {
            throw new BadRequestException("Last name must be less than 50 characters");
        }
    }

    private void ValidateEmail(string email)
    {
        if (email.Length > 100)
        {
            throw new BadRequestException("Email must be less than 100 characters");
        }
    }
}
