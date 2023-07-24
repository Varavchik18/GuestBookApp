namespace Domain.Models;
public class Note
{
    public int Id{get;set;}
    public string? Title{get;set;}
    public string? Description{get;set;}
    public string? DateTimeCreated{get;set;}
    public string? AuthorName {get;set;}
}