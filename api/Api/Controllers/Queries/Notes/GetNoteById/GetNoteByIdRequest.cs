using MediatR;
namespace Api.Controllers.Queries.Notes;

public class GetNoteByIdRequest : IRequest<GetNoteByIdResponse>
{
    public int IdNote { get; set; }
}