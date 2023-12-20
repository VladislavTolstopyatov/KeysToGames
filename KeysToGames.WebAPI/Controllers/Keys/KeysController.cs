using KeysToGames.Controllers.Genres.Entities;
using KeysToGames.Controllers.Keys.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeysToGames.Controllers.Keys
{
    [ApiController]
    [Route("controller")]
    public class KeysController : ControllerBase
    {

        public KeysController() { }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllKeys()
        {
            // call service
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetKeyDetails([FromRoute] Guid id)
        {
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateKey([FromBody] CreateKeyBody body)
        {
            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateKeyInfo([FromRoute] Guid id, UpdateKeyBody body)
        {
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteKey([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
