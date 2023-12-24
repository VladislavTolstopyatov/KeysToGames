using KeysToGames.WebAPI.Settings;

namespace KeysToGames.WebAPI.Settings
{
    public class KeysToGamesSettingsReader
    {
        public static KeysToGamesSettings Read(IConfiguration configuration)
        {
            //здесь будет чтение настроек приложения из конфига
            return new KeysToGamesSettings()
            {
                ServiceUri = configuration.GetValue<Uri>("Uri"),
                KeysToGamesDbContextConnectionString = configuration.GetValue<string>("KeysToGamesDbContext"),
                IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri"),
                ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
                ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            };
        }
    }
}