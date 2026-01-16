using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TtrpgManager.Infrastructure.Persistence;

public sealed class TtrpgManagerDbContextFactory : IDesignTimeDbContextFactory<TtrpgManagerDbContext>
{
    public TtrpgManagerDbContext CreateDbContext(string[] args)
    {
        var slnDir = FindSolutionDirectory();
        var apiProjectPath = Path.Combine(slnDir.FullName, "TtrpgManager.Api");

        if (!Directory.Exists(apiProjectPath))
        {
            throw new DirectoryNotFoundException($"API project folder not found: '{apiProjectPath}'");
        }

        var configuration = new ConfigurationBuilder()
            .SetBasePath(apiProjectPath)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("Default");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'Default' not found in appsettings.json.");
        }

        var optionsBuilder = new DbContextOptionsBuilder<TtrpgManagerDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new TtrpgManagerDbContext(optionsBuilder.Options);
    }

    private static DirectoryInfo FindSolutionDirectory()
    {
        var dir = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (dir is not null)
        {
            var slnFiles = dir.GetFiles("*.sln", SearchOption.TopDirectoryOnly);
            if (slnFiles.Length > 0)
            {
                return dir;
            }

            dir = dir.Parent;
        }

        throw new DirectoryNotFoundException(
            $"Solution directory not found. CurrentDirectory='{Directory.GetCurrentDirectory()}'"
        );
    }
}
