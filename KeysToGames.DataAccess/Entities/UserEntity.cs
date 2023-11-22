using System.ComponentModel.DataAnnotations.Schema;

namespace KeysToGames.DataAccess.Entities
{
    [Table("Users")]
    public class UserEntity : BaseEntity
    {
        public string Login { get; set; }
        public int PasswordHash { get; set; }
        public float MoneyBalance { get; set; }
        public string CardNumber { get; set; }

        public ICollection<DealEntity> Deals { get; set; } 
    }
}
