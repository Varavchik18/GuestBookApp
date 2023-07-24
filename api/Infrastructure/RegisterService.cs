using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace GuestBookApp.Infrastructure;
public static class RegisterService
{
public static void ConfigureInfraStructure(this IServiceCollection services, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
    services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
}

}