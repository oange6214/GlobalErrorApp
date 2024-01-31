using GlobalErrorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalErrorApp.Data;
public class AppDbContext : DbContext
{
    public DbSet<Driver> Drivers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}