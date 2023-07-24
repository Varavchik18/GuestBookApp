using Microsoft.EntityFrameworkCore;
using Domain.Models;
public interface IAppDbContext
{
    DbSet<Note> Notes{get;}
    Task<int> SaveToDbAsync();
}