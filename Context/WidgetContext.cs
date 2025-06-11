using Microsoft.EntityFrameworkCore;
using VersioningDemo.Entities;

namespace VersioningDemo.Context;

public class WidgetContext : DbContext
{
    public WidgetContext(DbContextOptions<WidgetContext> options) : base(options) { }
    
    public WidgetContext() { }
    
    public DbSet<Widget> Widgets { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    //     
    //     // Optional: Configure your entities here
    //     modelBuilder.Entity<Widget>(entity =>
    //     {
    //         entity.HasKey(w => w.Id);
    //         // Add any specific configurations for Widget
    //     });
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=np_dev;Username=postgres;Password=postgres");
        }
    }
}