using KeysToGames.BL.Games;
using KeysToGames.BL.Users;
using KeysToGames.DataAccess;

namespace KeysToGames.IoC
{
    public static class ServicesConfigurator
    {
        public static void ConfigureServices(IServiceCollection services) 
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IGamesProvider,GamesProvider>();
            services.AddScoped<IGamesManager, GamesManager>();

            services.AddScoped<IUsersProvider, UsersProvider>();
            services.AddScoped<IUsersManager, UsersManager>();

            // services.AddSwaggerGen(c => c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()));
        }
    }
}
