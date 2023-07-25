using MediatR;
namespace Api.Controllers.Commands.Authors;

public class DeleteAuthorCommand : IRequest<int>
{
    protected internal int IdAuthor { get; set; }
}