using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class Comment
{
    [Key]
    public int IdComment { get; set; }
    [MaxLength(50)]
    public string? Title { get; set; }
    [MaxLength(500)]
    public string? Description { get; set; }
    public DateTimeOffset DateTimeCreated { get; set; }
    public DateTimeOffset DateTimeUpdated { get; set; }
    [MaxLength(500)]
    public string? ImageUrl { get; set; }
    public Author Author { get; set; }

    public Comment()
    {
    }

    public Comment(string title, string description, DateTimeOffset dateTimeCreated, DateTimeOffset dateTimeUpdated, Author author, string imageUrl)
    {
        Title = title;
        Description = description;
        DateTimeCreated = dateTimeCreated;
        DateTimeUpdated = dateTimeUpdated;
        Author = author;
        ImageUrl = imageUrl;
    }

    public void Update(string title, string description, DateTimeOffset dateTimeUpdated, string imageUrl)
    {
        Title = title;
        Description = description;
        DateTimeUpdated = dateTimeUpdated;
        ImageUrl = imageUrl;
    }

    public void UpdateAuthorInfo(Author author)
    {
        Author = author;
    }

    public void UpdateDate(DateTimeOffset dateTimeCreated, DateTimeOffset dateTimeUpdated)
    {
        DateTimeCreated = dateTimeCreated;
        DateTimeUpdated = dateTimeUpdated;
    }

}