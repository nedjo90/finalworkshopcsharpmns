using backend.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;


namespace backend.MigrationsManager;

public static class MigrationsManager
{
    private static int _numberOfRetries = 0;
    private const int MaxRetries = 6;
    private const int DelayMilliseconds = 10000;
    public static async Task MigrateDatabase(this IHost host)
    {
        using IServiceScope scope = host.Services.CreateScope();
        await using BackendContext appContext = scope.ServiceProvider.GetRequiredService<BackendContext>();
        try
        {
            await appContext.Database.MigrateAsync();
            Console.WriteLine("Database migration applied successfully.");
            _numberOfRetries = 0; // Réinitialiser le compteur après un succès
        }
        catch (Exception ex) when (ex is MySqlException or SqlException)
        {
            if (_numberOfRetries < MaxRetries)
            {
                _numberOfRetries++;
                Console.WriteLine($"The server was not found or was not accessible. Retrying... #{_numberOfRetries}");
                await Task.Delay(DelayMilliseconds);
                await MigrateDatabase(host);
            }
            else
            {
                Console.WriteLine("Migration failed after multiple retries.");
                throw;
            }
        }

    }
}