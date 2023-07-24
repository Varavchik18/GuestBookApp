using MediatR;
namespace Api.Controllers.Queries.Authors;

public class GetAuthorsRequest : IRequest<List<GetAuthorsResponse>>
{
}