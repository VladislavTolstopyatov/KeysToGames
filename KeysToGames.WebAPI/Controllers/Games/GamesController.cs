using AutoMapper;
using KeysToGames.BL.Games;
using KeysToGames.BL.Games.Entities;
using KeysToGames.Controllers.Games.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeysToGames.Controllers.Games
{
    [ApiController]
    [Route("controller")]
    public class GamesController : ControllerBase
    {
        private readonly IGamesManager _gamesManager;
        private readonly IGamesProvider _gamesProvider;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GamesController(IGamesManager gamesManager, IGamesProvider gamesProvider,IMapper mapper, ILogger logger)
        {
            _gamesManager = gamesManager;
            _gamesProvider = gamesProvider;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllGames()
        {
            var games = _gamesProvider.GetAllGames();

            return Ok(new GamesListResponse()
            {
                Games = games.ToList()
            }); 
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGameDetails([FromRoute] Guid id)
        {
            try
            {
                var game = _gamesProvider.GetGameInfo(id);
                return Ok(game); // 200
            }
            catch (ArgumentException ex) 
            {
                _logger.LogError(ex.ToString());

                return NotFound(ex.Message);
                // return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateGame([FromBody] CreateGameBody body)
        {
            var game = _gamesManager.CreateGame(_mapper.Map<CreateGameModel>(body));

            return Ok(game);
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateGameInfo([FromRoute] Guid id, UpdateGameBody body)
        {
            try
            {
                var game = _gamesManager.UpdateGame(id, _mapper.Map<GameModel>(body));

                return Ok(game);
            }
            catch(ArgumentException ex) 
            {
                _logger.LogError(ex.ToString());

                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteGame([FromRoute] Guid id)
        {
            try
            {
                _gamesManager.DeleteGame(id);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());

                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("filter")]
        public IActionResult GetFilteredGames([FromQuery] GameFilter filter)
        {
            var games = _gamesProvider.GetAllGamesWithFilter(_mapper.Map<GameModelFilter>(filter));

            return Ok(new GamesListResponse()
            {
                Games = games.ToList()
            });
        }
    }
}
