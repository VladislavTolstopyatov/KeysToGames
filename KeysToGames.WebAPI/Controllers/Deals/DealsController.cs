using KeysToGames.Controllers.Deals.Entities;
using KeysToGames.Controllers.Keys.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KeysToGames.Controllers.Deals
{
    [ApiController]
    [Route("controller")]
    public class DealsController : ControllerBase
    {

        public DealsController() { }

        [HttpGet]
        public IActionResult GetAllDeals()
        {
            // call service
            return Ok();
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDealDetails([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateDeal([FromBody] CreateDealBody body)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateDealInfo([FromRoute] Guid id, UpdateDealBody body)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDeal([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
