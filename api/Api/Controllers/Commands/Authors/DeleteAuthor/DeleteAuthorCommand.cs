using MediatR;
namespace Api.Controllers.Commands.Authors;

public class DeleteAuthorCommand : IRequest<int>
{
    public int IdAuthor { get; set; }
}