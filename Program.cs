using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VersioningDemo.Context;

Console.WriteLine("Application starting...");

var builder = Host.CreateApplicationBuilder(args);
ConfigureServices(builder.Services);
var host = builder.Build();

await host.RunAsync();

Console.WriteLine("Application finished.");

static void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<WidgetContext>(options =>
        options.UseNpgsql("Host=localhost;Port=7432;Database=np_dev;Username=postgres;Password=postgres;"));
}