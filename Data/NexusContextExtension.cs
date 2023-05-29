using Microsoft.Extensions.DependencyInjection; // IServiceCollection
using Microsoft.EntityFrameworkCore; // UseSqlLite

namespace Nexus.Data;


public static class NexusContextExtension
{
    public static IServiceCollection AddNexusContext(this IServiceCollection services, string relativePath = "..")
    {
        string databasePath = Path.Combine(relativePath, "Nexus.db");
        services.AddDbContext<NexusContext>(options =>
        {
            options.UseSqlite($"Data Source={databasePath}");
            options.LogTo(Console.WriteLine, // Console
                new[] { Microsoft.EntityFrameworkCore
                    .Diagnostics.RelationalEventId.CommandExecuting });
        });
        return services;
    }
}