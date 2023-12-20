using KeysToGames.Controllers.Games.Entities;
using KeysToGames.Controllers.Genres.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeysToGames.Controllers.Genres
{
    [ApiController]
    [Route("controller")]
    public class GenresController : ControllerBase
    {

        public GenresController() { }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllGenres()
        {
            // call service
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGenreDetails([FromRoute] Guid id)
        {
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreBody body)
        {
            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateGameInfo([FromRoute] Guid id, UpdateGenreBody body)
        {
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteGenre([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
