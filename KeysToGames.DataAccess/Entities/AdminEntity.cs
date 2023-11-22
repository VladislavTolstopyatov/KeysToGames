using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.DataAccess.Entities
{
    [Table("Admins")]
    public class AdminEntity : BaseEntity
    {
        public string Login {  get; set; }
        public int PasswordHash { get; set; }
    }
}
