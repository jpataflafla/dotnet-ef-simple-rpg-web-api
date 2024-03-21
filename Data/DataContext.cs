using dotnet_ef_simple_rpg_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ef_simple_rpg_web_api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Character> Characters => Set<Character>();
    public DbSet<User> Users => Set<User>();
}
