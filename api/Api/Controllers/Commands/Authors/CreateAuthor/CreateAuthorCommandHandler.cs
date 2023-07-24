using Domain.Models;
using MediatR;
namespace Api.Controllers.Commands.Authors;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
{
    private readonly AppDbContext _context;

    public CreateAuthorCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        Validate(request.FirstName, request.LastName, request.Phone, request.Email);
        var author = new Author(request.FirstName, request.LastName, request.Phone, request.Email);
        await _context.Authors.AddAsync(author);
        await _context.SaveToDbAsync();
        return author.IdAuthor;
    }

    private void Validate(string firstName, string lastName, string phone, string email)
    {
        ValidateFirstName(firstName);
        ValidateLastName(lastName);
        ValidatePhone(phone);
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

    private void ValidatePhone(string phone)
    {
        if (phone.Length > 13)
        {
            throw new BadRequestException("Phone must be less than 13 characters");
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
