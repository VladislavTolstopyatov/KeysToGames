using System.ComponentModel.DataAnnotations.Schema;

namespace KeysToGames.DataAccess.Entities
{
    [Table("Genres")]
    public class GenreEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<GameEntity> Games { get; set; } 
    }
}
