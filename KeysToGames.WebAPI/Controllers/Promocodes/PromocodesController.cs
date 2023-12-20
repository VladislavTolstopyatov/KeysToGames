using KeysToGames.Controllers.Genres.Entities;
using KeysToGames.Controllers.Promocodes.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeysToGames.Controllers.Promocodes
{
    [ApiController]
    [Route("controller")]
    public class PromocodesController : ControllerBase
    {
        public PromocodesController() { }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllPromocodes()
        {
            // call service
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPromocodeDetails([FromRoute] Guid id)
        {
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreatePromocode([FromBody] CreatePromocodeBody body)
        {
            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdatePromocodeInfo([FromRoute] Guid id, UpdatePromocodeBody body)
        {
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePromocode([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
