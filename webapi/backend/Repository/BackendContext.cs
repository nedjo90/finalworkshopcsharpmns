using backend.Models;
using backend.Repository.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class BackendContext : IdentityDbContext<User>
{
    public DbSet<Animal>? Animals { get; set; }
    public DbSet<Race>? Races { get; set; }

    public BackendContext(DbContextOptions<BackendContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new RaceConfiguration());
        modelBuilder.ApplyConfiguration(new AnimalConfiguration());
    }
}