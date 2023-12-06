using KeysToGames.Controllers.Admin.Entities;
using KeysToGames.Controllers.Users.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KeysToGames.Controllers.Admin
{
    [ApiController]
    [Route("controller")]
    public class AdminController : ControllerBase
    {
        // log in
        // log out

        public AdminController() { }

        [HttpPost]
        public IActionResult RegisterAdmin([FromBody] RegisterAdminBody body)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateAdmiInfo([FromRoute] Guid id, UpdateAdminBody body)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAdmin([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
