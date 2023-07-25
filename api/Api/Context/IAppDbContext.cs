using Domain.Models;
using Microsoft.EntityFrameworkCore;
public interface IAppDbContext
{
    DbSet<Comment> Comments { get; }
    DbSet<Author> Authors { get; }
    Task<int> SaveToDbAsync();
}