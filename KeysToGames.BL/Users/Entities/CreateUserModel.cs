using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Users.Entities
{
    public class CreateUserModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public int PasswordHash { get; set; }
        [Required]
        public float MoneyBalance { get; set; }
        [Required]
        public string CardNumber { get; set; }
    }
}
