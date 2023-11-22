using KeysToGames.DataAccess;
using KeysToGames.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KeysToGames.UnitTests.Repository
{
    public class RepositoryTestBase
    {
        protected readonly KeysToGamesSettings Settings;
        protected readonly IDbContextFactory<KeysToGamesDbContext> DbContextFactory;
        protected readonly IServiceProvider ServiceProvider;
        public RepositoryTestBase()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            Settings = KeysToGamesSettingsReader.Read(configuration);
            ServiceProvider = ConfigureServiceProvider();

            DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<KeysToGamesDbContext>>();
        }

        private IServiceProvider ConfigureServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContextFactory<KeysToGamesDbContext>(
                options => { options.UseSqlServer(Settings.KeysToGamesDbContextConnectionString); },
                ServiceLifetime.Scoped);
            return serviceCollection.BuildServiceProvider();
        }
    }
}
