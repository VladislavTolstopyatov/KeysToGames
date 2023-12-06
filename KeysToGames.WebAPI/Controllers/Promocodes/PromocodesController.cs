using KeysToGames.Controllers.Genres.Entities;
using KeysToGames.Controllers.Promocodes.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KeysToGames.Controllers.Promocodes
{
    [ApiController]
    [Route("controller")]
    public class PromocodesController : ControllerBase
    {
        public PromocodesController() { }

        [HttpGet]
        public IActionResult GetAllPromocodes()
        {
            // call service
            return Ok();
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPromocodeDetails([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreatePromocode([FromBody] CreatePromocodeBody body)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdatePromocodeInfo([FromRoute] Guid id, UpdatePromocodeBody body)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePromocode([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
