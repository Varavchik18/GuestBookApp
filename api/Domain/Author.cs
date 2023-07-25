using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Author
    {
        [Key]
        public int IdAuthor { get; set; }
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(13)]
        public string? Phone { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public Author()
        {
        }

        public Author(string firstName, string lastName, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public void Update(string firstName, string lastName, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }
    }
}