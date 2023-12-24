using KeysToGames.BL.Auth;
using KeysToGames.BL.Games;
using KeysToGames.BL.Users;
using KeysToGames.DataAccess;
using KeysToGames.DataAccess.Entities;
using KeysToGames.WebAPI.Settings;
using Microsoft.AspNetCore.Identity;

namespace KeysToGames.IoC
{
    public class ServicesConfigurator
    {
        public static void ConfigureServices(IServiceCollection services,KeysToGamesSettings settings) 
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IGamesProvider,GamesProvider>();
            services.AddScoped<IGamesManager, GamesManager>();

            services.AddScoped<IUsersProvider, UsersProvider>();
            services.AddScoped<IUsersManager, UsersManager>();

            services.AddScoped<IAuthProvider>(x =>
    new AuthProvider(x.GetRequiredService<SignInManager<UserEntity>>(),
        x.GetRequiredService<UserManager<UserEntity>>(),
        x.GetRequiredService<IHttpClientFactory>(),
        settings.IdentityServerUri,
        settings.ClientId,
        settings.ClientSecret));

            services.AddSwaggerGen(c => c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()));
        }
    }
}
