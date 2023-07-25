using MediatR;
namespace Api.Controllers.Commands.Authors;

public class UpdateAuthorCommand : IRequest<int>
{
    protected internal int IdAuthor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}