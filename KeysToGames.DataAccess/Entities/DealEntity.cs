using System.ComponentModel.DataAnnotations.Schema;

namespace KeysToGames.DataAccess.Entities
{
    public class DealEntity : BaseEntity
    {
        public DateTime DateOfDeal { get; set; }
        public int? PromocodeId { get; set; }
        public PromocodeEntity? Promocode { get; set; }
        public int GameId { get; set; }
        public GameEntity Game { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
