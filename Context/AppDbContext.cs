using Domain.Models;
using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
    public DbSet<Note> Notes {get;set;}
    public async Task<int> SaveToDbAsync()
    {
        return await SaveChangesAsync();
    }
}