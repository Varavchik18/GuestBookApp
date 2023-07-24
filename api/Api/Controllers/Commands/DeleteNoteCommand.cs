using MediatR;

public class DeleteNoteCommand : IRequest<int>
{
    public int IdNote { get; set; }
}