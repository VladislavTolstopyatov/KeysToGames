using KeysToGames.DataAccess.Entities;

namespace KeysToGames.Controllers.Deals.Entities
{
    public class CreateDealBody
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
