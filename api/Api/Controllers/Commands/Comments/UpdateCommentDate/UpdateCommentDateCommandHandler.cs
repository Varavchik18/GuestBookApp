using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers.Commands.Comments;
public class UpdateCommentDateCommandHandler : IRequestHandler<UpdateCommentDateCommand, int>
{
    private readonly AppDbContext _context;

    public UpdateCommentDateCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateCommentDateCommand request, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments.SingleOrDefaultAsync(x => x.IdComment == request.IdComment);
        Validate(comment, request.DateTimeCreated);
        comment.UpdateDate(request.DateTimeCreated, request.DateTimeUpdated);
        await _context.SaveToDbAsync();
        return comment.IdComment;
    }

    private void Validate(Comment comment, DateTimeOffset dateCreated)
    {
        ValidateDate(dateCreated);
        ValidateComment(comment);
    }

    private void ValidateComment(Comment comment)
    {
        if(comment == null){
            throw new NotFoundException("Comment not found");
        }
    }

    private void ValidateDate(DateTimeOffset dateCreated)
    {
        if(dateCreated > DateTimeOffset.Now){
            throw new BadRequestException("Date cannot be in the future");
        }
        if(dateCreated == null || dateCreated == default){
            throw new BadRequestException("Date cannot be null or empty");
        }
    }
}