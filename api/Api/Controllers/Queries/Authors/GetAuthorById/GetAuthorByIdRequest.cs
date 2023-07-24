using MediatR;

public class GetAuthorByIdRequest : IRequest<GetAuthorByIdResponse>
{
    public int IdAuthor { get; set; }
}