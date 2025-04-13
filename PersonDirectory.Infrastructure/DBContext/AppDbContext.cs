

using Microsoft.EntityFrameworkCore;
using PersonDirectory.Core.Models;

namespace PersonDirectory.Infrastructure.DBContext;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person_Detail> Person_Details { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
