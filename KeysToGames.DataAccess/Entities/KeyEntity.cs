using System.ComponentModel.DataAnnotations.Schema;

namespace KeysToGames.DataAccess.Entities
{
    [Table("Keys")]
    public class KeyEntity : BaseEntity
    {
        public string KeyStr { get; set; }
        public bool IsActual { get; set; }
        public int GameId { get; set; }
        public GameEntity Game { get; set; }
    }
}
