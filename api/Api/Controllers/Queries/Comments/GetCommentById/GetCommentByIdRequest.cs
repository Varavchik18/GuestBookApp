using MediatR;
namespace Api.Controllers.Queries.Comments;

public class GetCommentByIdRequest : IRequest<GetCommentByIdResponse>
{
    public int IdComment { get; set; }
}