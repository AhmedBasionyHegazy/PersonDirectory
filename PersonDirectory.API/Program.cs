using Microsoft.EntityFrameworkCore;
using PersonDirectory.Core.RepositoryContract;
using PersonDirectory.Core.Service;
using PersonDirectory.Infrastructure.DBContext;
using PersonDirectory.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services
builder.Services.AddScoped<IPersonRepository, CsvPersonRepository>();
builder.Services.AddScoped<IPersonRepository, SqlPersonRepository>();
builder.Services.AddScoped<PersonService>();

// EF Core setup
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
