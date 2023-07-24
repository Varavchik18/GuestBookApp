using MediatR;

public class GetNoteByIdRequest: IRequest<GetNoteByIdResponse>
{
    public int IdNote { get; set; }
}