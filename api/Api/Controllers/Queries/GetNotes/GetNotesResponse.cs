using Domain.Models;

public class GetNotesResponse{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset DateTimeCreated { get; set; }
    public DateTimeOffset DateTimeUpdated { get; set; }
    public Author Author { get; set; }
}