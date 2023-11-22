using System.ComponentModel.DataAnnotations.Schema;

namespace KeysToGames.DataAccess.Entities
{
    [Table("Promocodes")]
    public class PromocodeEntity : BaseEntity
    {
        public string PromocodeStr {  get; set; }
        public int DiscountProcent {  get; set; }

        public ICollection<DealEntity> Deals { get; set; }
    }
}
