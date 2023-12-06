using KeysToGames.BL.Games.Entities;
using KeysToGames.BL.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Users
{
    public interface IUsersProvider
    {
        IEnumerable<UserModel> GetAllUsers();
        IEnumerable<UserModel> GetAllUsersWithFilter(UserModelFilter filter);
        UserModel GetUserInfo(Guid userId);
    }
}
