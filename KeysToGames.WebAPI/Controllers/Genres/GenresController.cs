using KeysToGames.Controllers.Games.Entities;
using KeysToGames.Controllers.Genres.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KeysToGames.Controllers.Genres
{
    [ApiController]
    [Route("controller")]
    public class GenresController : ControllerBase
    {

        public GenresController() { }   

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            // call service
            return Ok();
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGenreDetails([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreBody body)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateGameInfo([FromRoute] Guid id, UpdateGenreBody body)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteGenre([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
