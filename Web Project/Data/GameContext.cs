using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Web_Project.Models;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Games { get; set; } = default!;

    public DbSet<Platform> Platforms { get; set; } = default!;
    public DbSet<GameState> gameStates { get; set; } = default!;

    public DbSet<Admin> admins { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .HasOne(p => p.GameState)
            .WithMany(b => b.Games);

        modelBuilder.Entity<Game>()
            .HasOne(p => p.Platform)
            .WithMany(b => b.Games);

    }
   
}

