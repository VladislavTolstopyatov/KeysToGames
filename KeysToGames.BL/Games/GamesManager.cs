using AutoMapper;
using KeysToGames.BL.Games.Entities;
using KeysToGames.DataAccess;
using KeysToGames.DataAccess.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KeysToGames.BL.Games
{
    public class GamesManager : IGamesManager
    {
        private readonly IRepository<GameEntity> _gamesRepository;
        private readonly IMapper _mapper;

       public GamesManager(IRepository<GameEntity> gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }

        public GameModel CreateGame(CreateGameModel game)
        {
            var entity = _mapper.Map<GameEntity>(game);

            _gamesRepository.Save(entity); // id, creationTime, external id

            return _mapper.Map<GameModel>(game);
        }

        public void DeleteGame(Guid id)
        {
            var entity = _gamesRepository.GetById(id);

            if (entity is null)
            {
                throw new ArgumentException("Game not found");
            }
            _gamesRepository.Delete(entity);
        }

        public GameModel UpdateGame(Guid id, GameModel model)
        {
            var entity = _gamesRepository.GetById(id);
            
            if (entity is null) 
            {
                throw new ArgumentException("Game not found");
            }

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.DateOfRelease = model.DateOfRelease;
            entity.DeveloperCompany = model.DeveloperCompany;
            entity.Genre = model.Genre;
            entity.GenreId = model.GenreId;

            // ? modification time,id,external Id?

            _gamesRepository.Save(entity);

            return _mapper.Map<GameModel>(entity);
        }
    }
}
