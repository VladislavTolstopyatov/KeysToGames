namespace KeysToGames.WebAPI.Settings
{
    public class KeysToGamesSettings
    {
        public Uri ServiceUri { get; set; }
        public string KeysToGamesDbContextConnectionString { get; set; }
        public string IdentityServerUri { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

    }
}