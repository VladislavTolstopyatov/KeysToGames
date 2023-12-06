using KeysToGames.BL.Games.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Games
{
    public interface IGamesManager  // создание, удаление, изменение
    {
        GameModel CreateGame(CreateGameModel game);
        void DeleteGame(Guid id);
        GameModel UpdateGame(Guid id,GameModel model);
    }
}
