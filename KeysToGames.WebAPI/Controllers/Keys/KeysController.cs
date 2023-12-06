using KeysToGames.Controllers.Genres.Entities;
using KeysToGames.Controllers.Keys.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KeysToGames.Controllers.Keys
{
    [ApiController]
    [Route("controller")]
    public class KeysController : ControllerBase
    {

        public KeysController() { }

        [HttpGet]
        public IActionResult GetAllKeys()
        {
            // call service
            return Ok();
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetKeyDetails([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateKey([FromBody] CreateKeyBody body)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateKeyInfo([FromRoute] Guid id, UpdateKeyBody body)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteKey([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
