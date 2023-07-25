using Domain.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext, IAppDbContext
{
    private readonly string _connectionString;

    public DbSet<Comment> Comments { get; set; }
    public DbSet<Author> Authors { get; set; }
    public AppDbContext() : base()
    { }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public async Task<int> SaveToDbAsync()
    {
        return await SaveChangesAsync();
    }
}