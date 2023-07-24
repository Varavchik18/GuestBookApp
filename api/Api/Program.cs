using System.Reflection;
using GuestBookApp.Infrastructure;
var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // Register AutoMapper profiles
builder.Services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.ConfigureInfraStructure(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
