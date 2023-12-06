using KeysToGames.DataAccess.Entities;

namespace KeysToGames.Controllers.Keys.Entities
{
    public class CreateKeyBody
    {
        public string KeyStr { get; set; }
        public bool IsActual { get; set; }
        public int GameId { get; set; }
        public GameEntity Game { get; set; }
    }
}
