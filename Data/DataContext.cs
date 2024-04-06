using dotnet_ef_simple_rpg_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ef_simple_rpg_web_api.Data;

public class DataContext : DbContext
{
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Weapon> Weapons => Set<Weapon>();

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

        // set default user.Role to "Player"
        modelBuilder.Entity<User>()
            .Property(user => user.Role).HasDefaultValue("Player");

        // add default test users
        // AuthUtility.CreatePasswordHash("TestUser", out byte[] passwordHash, out byte[] passwordSalt);
        // modelBuilder.Entity<User>().HasData(
        //     new User()
        //     {
        //         Id = 1,
        //         PasswordHash = passwordHash,
        //         PasswordSalt = passwordSalt,
        //         Username = "TestUser1",
        //         Role = "Admin"
        //     },
        //     new User()
        //     {
        //         Id = 2,
        //         PasswordHash = passwordHash,
        //         PasswordSalt = passwordSalt,
        //         Username = "TestUser2",
        //         Role = "Player"
        //     }
        // );

        // modelBuilder.Entity<Character>().HasData(
        //     new Character()
        //     {
        //         Id = 1,
        //         Name = "TestCharacter1",
        //         Class = RpgClass.Cleric,
        //         HitPoints = 100,
        //         Strength = 60,
        //         Defense = 60,
        //         Intelligence = 90,
        //         UserId = 1
        //     },
        //     new Character()
        //     {
        //         Id = 2,
        //         Name = "TestCharacter2",
        //         Class = RpgClass.Rogue,
        //         HitPoints = 100,
        //         Strength = 50,
        //         Defense = 50,
        //         Intelligence = 80,
        //         UserId = 2
        //     },
        //     new Character()
        //     {
        //         Id = 3,
        //         Name = "TestCharacter3",
        //         Class = RpgClass.Rogue,
        //         HitPoints = 100,
        //         Strength = 50,
        //         Defense = 50,
        //         Intelligence = 80,
        //         UserId = 2,
        //     }
        // );
    }
}
