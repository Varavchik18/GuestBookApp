using Domain.Models;
namespace Api.Controllers.Queries.Comments;

public class GetCommentByIdResponse
{
    public int IdComment { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public DateTimeOffset DateTimeCreated { get; set; }
    public DateTimeOffset DateTimeUpdated { get; set; }
    public AuthorInfoDTO Author { get; set; }
}