using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Users.Entities
{
    public class UserModel
    {
        public Guid id { get; set; }
        public string Login { get; set; }
        public int PasswordHash { get; set; }
        public float MoneyBalance { get; set; }
        public string CardNumber { get; set; }
    }
}
