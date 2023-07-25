using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class Comment
{
    [Key]
    public int IdComment { get; set; }
    [MaxLength(50)]
    public string? Title { get; set; }
    [MaxLength(100)]
    public string? Description { get; set; }
    public DateTimeOffset DateTimeCreated { get; set; }
    public DateTimeOffset DateTimeUpdated { get; set; }
    public Author Author { get; set; }

    public Comment()
    {
    }

    public Comment(string title, string description, DateTimeOffset dateTimeCreated, DateTimeOffset dateTimeUpdated, Author author)
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

    public void UpdateAuthorInfo(Author author)
    {
        Author = author;
    }

}