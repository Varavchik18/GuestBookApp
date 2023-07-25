namespace Api.Controllers.Queries.Authors;
public class GetAuthorsResponse
{
    public int IdAuthor { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}