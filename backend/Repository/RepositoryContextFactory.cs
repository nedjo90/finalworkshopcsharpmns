using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace backend.Repository;

public class RepositoryContextFactory: IDesignTimeDbContextFactory<BackendContext>
{
    public BackendContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        DbContextOptionsBuilder<BackendContext>? builder = 
            new DbContextOptionsBuilder<BackendContext>()
                .UseMySql(connectionString: configuration.GetConnectionString("Default") ?? throw new InvalidOperationException(),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("Default")));
        return new BackendContext(builder.Options);
    }
}