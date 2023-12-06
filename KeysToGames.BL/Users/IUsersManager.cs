using KeysToGames.BL.Games.Entities;
using KeysToGames.BL.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Users
{
    public interface IUsersManager
    {
        UserModel CreateUser(CreateUserModel game);
        void DeleteUser(Guid id);
        UserModel UpdateUser(Guid id, UpdateUserModel model);
    }
}
