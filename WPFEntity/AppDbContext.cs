using Microsoft.EntityFrameworkCore;
using WPFEntity.Models;

namespace WPFEntity;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;database=console_app_db;user=root;password=",
            new MySqlServerVersion(new Version(8, 0, 21)));
    }
    
}