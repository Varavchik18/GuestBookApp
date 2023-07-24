namespace Domain.Models;
public class Note
{
    public int IdNote{get;set;}
    public string? Title{get;set;}
    public string? Description{get;set;}
    public DateTimeOffset DateTimeCreated{get;set;}
    public DateTimeOffset DateTimeUpdated{get;set;}
    public Author Author { get; set; }

    public Note(string title, string description, DateTimeOffset dateTimeCreated, DateTimeOffset dateTimeUpdated, Author author)
    {
        Title = title;
        Description = description;
        DateTimeCreated = dateTimeCreated;
        DateTimeUpdated = dateTimeUpdated;
        Author = author;
    }

    public void Update(string title, string description, DateTimeOffset dateTimeUpdated)
    {
        Title = title;
        Description = description;
        DateTimeUpdated = dateTimeUpdated;
    }

    public void UpdateAuthorInfo(Author author){
        Author = author;
    }
    
}