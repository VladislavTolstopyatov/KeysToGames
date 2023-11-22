using System.ComponentModel.DataAnnotations.Schema;

namespace KeysToGames.DataAccess.Entities
{
    [Table("Games")]
    public class GameEntity :BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfRelease { get; set; }
        public string DeveloperCompany { get; set; }
        public int Price { get; set; }
        public int GenreId { get; set; }
        public GenreEntity Genre { get; set; }

        public ICollection<KeyEntity> Keys { get; set; } // ключи для данной игры

        public ICollection<DealEntity> Deals { get; set; }

    }
}
