using MediatR;
namespace Api.Controllers.Queries.Notes;

public class GetNotesRequest : IRequest<List<GetNotesResponse>>
{
}