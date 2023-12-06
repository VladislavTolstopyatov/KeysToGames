using KeysToGames.BL.Mapper;
using KeysToGames.Mapper;
using KeysToUsers.Mapper;

namespace KeysToGames.IoC
{
    public static class MapperConfigurator
    {
        public static void ConfigureServices(IServiceCollection services) 
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<GamesBLProfile>();
                config.AddProfile<GamesServiceProfile>();
                config.AddProfile<UsersBLProfile>();
                config.AddProfile<UsersServiceProfile>();
            });
        }
    }
}
