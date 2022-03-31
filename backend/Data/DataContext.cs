using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Data.Mappings;

namespace backend.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Auth> Auths { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserMap());
      modelBuilder.ApplyConfiguration(new AuthMap());
    }
  }
}