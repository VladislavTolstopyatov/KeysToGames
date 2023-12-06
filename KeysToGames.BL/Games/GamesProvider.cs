using AutoMapper;
using KeysToGames.BL.Games.Entities;
using KeysToGames.DataAccess;
using KeysToGames.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Games
{
    public class GamesProvider : IGamesProvider
    {
        private readonly IRepository<GameEntity> _gameRepository;
        private readonly IMapper _mapper;

        public GamesProvider(IRepository<GameEntity> gamesRepository, IMapper mapper) 
        {
            _gameRepository = gamesRepository;
            _mapper = mapper;
        }

        public GameModel GetGameInfo(Guid gameId)
        {
            var game = _gameRepository.GetById(gameId);

            if (game is null)
            {
                throw new ArgumentException("Game not found");
            }

            return _mapper.Map<GameModel>(game);
        }

        public IEnumerable<GameModel> GetAllGames()
        {
            var games = _gameRepository.GetAll();

            return _mapper.Map<IEnumerable<GameModel>>(games);  
        }

        public IEnumerable<GameModel> GetAllGamesWithFilter(GameModelFilter filter)
        {
            int? minimumPrice = filter?.minimumPrice;
            int? maximumPrice = filter?.maximumPrice;

            DateTime? dateOfRelease = filter?.dateOfRelease;

            var games =  _gameRepository.GetAll(x => x.Price > minimumPrice && x.Price < maximumPrice && x.DateOfRelease < dateOfRelease);

            return _mapper.Map<IEnumerable<GameModel>>(games);

        }
    }
}
