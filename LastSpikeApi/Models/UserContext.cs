using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace LastSpikeApi.Models
{
  public class UserContext : DbContext
  {
    public UserContext (DbContextOptions<UserContext> options) : base (options) { }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
      base.OnModelCreating (modelBuilder);

      modelBuilder.Entity<User> (entity =>
      {
        entity.HasKey (e => e.ID);
        entity.Property (e => e.Latitude);
        entity.Property (e => e.Longitude);
        entity.Property (e => e.Name);
      });
    }
  }
}