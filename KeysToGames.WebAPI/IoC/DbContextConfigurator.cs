using KeysToGames.DataAccess;
using KeysToGames.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;

namespace KeysToGames.IoC
{
    public class DbContextConfigurator
    {
        public static void ConfigureService(IServiceCollection services, KeysToGamesSettings settings)
        {
            services.AddDbContextFactory<KeysToGamesDbContext>(
                options => { options.UseSqlServer(settings.KeysToGamesDbContextConnectionString); },
                ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<KeysToGamesDbContext>>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist
        }
    }
}
