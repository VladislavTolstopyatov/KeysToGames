using KeysToGames.BL.Games.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Games
{
    public interface IGamesProvider // получение на чтение
    {
        IEnumerable<GameModel> GetAllGames();
        IEnumerable<GameModel> GetAllGamesWithFilter(GameModelFilter filter);
        GameModel GetGameInfo(Guid gameId);
    }
}
