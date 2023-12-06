using KeysToGames.DataAccess.Entities;

namespace KeysToGames.Controllers.Games.Entities
{
    public class UpdateGameBody
    {
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
