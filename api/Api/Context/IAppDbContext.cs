using Domain.Models;
using Microsoft.EntityFrameworkCore;
public interface IAppDbContext
{
    DbSet<Note> Notes { get; }
    DbSet<Author> Authors { get; }
    Task<int> SaveToDbAsync();
}