using MediatR;
namespace Api.Controllers.Queries.Comments;


public class GetCommentsRequest : IRequest<List<GetCommentsResponse>>
{
}