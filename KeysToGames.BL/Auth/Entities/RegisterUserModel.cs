using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Auth.Entities
{
    public class RegisterUserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public float MoneyBalance { get; set; }
        public string CardNumber { get; set; }
    }
}
