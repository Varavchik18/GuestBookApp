using System;
using Microsoft.EntityFrameworkCore;
public interface IDatabaseInitializer
{
    void Initialize();
}

public class DatabaseInitializer : IDatabaseInitializer
{
    private readonly AppDbContext _dbContext;

    public DatabaseInitializer(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Initialize()
    {
        try
        {
            _dbContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error migrating database: {ex.Message}");
        }
    }
}
