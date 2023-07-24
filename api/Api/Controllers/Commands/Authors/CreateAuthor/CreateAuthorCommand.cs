using MediatR;
namespace Api.Controllers.Commands.Authors;
public class CreateAuthorCommand : IRequest<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}