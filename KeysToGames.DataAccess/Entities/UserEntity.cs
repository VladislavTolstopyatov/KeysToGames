using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeysToGames.DataAccess.Entities
{
    [Table("Users")]
    public class UserEntity : IdentityUser<int>, IBaseEntity
    {
        public string Login { get; set; }
        public int PasswordHash { get; set; }
        public float MoneyBalance { get; set; }
        public string CardNumber { get; set; }

        public ICollection<DealEntity> Deals { get; set; }
        public Guid ExternalId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime ModificationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class UserRoleEntity : IdentityRole<int>
    {

    }
}
