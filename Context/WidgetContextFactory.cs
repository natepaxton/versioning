using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VersioningDemo.Context;

public class WidgetContextFactory : IDesignTimeDbContextFactory<WidgetContext>
{
    public WidgetContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WidgetContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=7432;Database=np_dev;Username=postgres;Password=postgres;");
        
        return new WidgetContext(optionsBuilder.Options);
    }
}