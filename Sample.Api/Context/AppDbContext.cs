using Microsoft.EntityFrameworkCore;
using Sample.Api.Models;

namespace Sample.Api.Context;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
}
