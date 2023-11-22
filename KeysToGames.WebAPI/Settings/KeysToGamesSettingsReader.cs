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
                KeysToGamesDbContextConnectionString = configuration.GetValue<string>("KeysToGamesDbContext")
            };
        }
    }
}