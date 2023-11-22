using System.ComponentModel.DataAnnotations;

namespace KeysToGames.DataAccess.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; } // ключ в бд

        public Guid ExternalId { get; set; }    // unique index 
        public DateTime ModificationTime { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
