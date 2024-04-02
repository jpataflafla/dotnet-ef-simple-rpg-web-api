using dotnet_ef_simple_rpg_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ef_simple_rpg_web_api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Weapon>().HasData(
            new Weapon { Id = 1, Name = "Hammer", Damage = 30 },
            new Weapon { Id = 2, Name = "Axe", Damage = 40 },
            new Weapon { Id = 3, Name = "Bow", Damage = 40 },
            new Weapon { Id = 4, Name = "Crossbow", Damage = 42 },
            new Weapon { Id = 5, Name = "Wand", Damage = 55 },
            new Weapon { Id = 6, Name = "Whip", Damage = 30 },
            new Weapon { Id = 7, Name = "Hot Potato", Damage = 10 }
        );

        modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = 1, Name = "Healing", Complexity = 90 },
            new Skill { Id = 2, Name = "Law", Complexity = 70 },
            new Skill { Id = 3, Name = "Poetry", Complexity = 40 },
            new Skill { Id = 4, Name = "Swimming", Complexity = 22 },
            new Skill { Id = 5, Name = "Dancing", Complexity = 15 },
            new Skill { Id = 6, Name = "Teleportation", Complexity = 99 },
            new Skill { Id = 7, Name = "Herbalism", Complexity = 80 }
        );

    }

    public DbSet<Character> Characters => Set<Character>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Weapon> Weapons => Set<Weapon>();
}
