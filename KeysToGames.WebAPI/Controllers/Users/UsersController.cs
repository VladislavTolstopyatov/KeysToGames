using AutoMapper;
using KeysToGames.BL.Users;
using KeysToGames.BL.Users.Entities;
using KeysToGames.Controllers.Users.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KeysToUsers.Controllers.Users
{
    [ApiController]
    [Route("controller")]
    public class UsersController : ControllerBase
    {
        // log in
        // log out

        private readonly IUsersManager _usersManager;
        private readonly IUsersProvider _usersProvider;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UsersController(IUsersManager usersManager, IUsersProvider usersProvider, IMapper mapper, ILogger logger)
        {
            _usersManager = usersManager;
            _usersProvider = usersProvider;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] RegisterUserBody body)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _usersProvider.GetAllUsers();

            return Ok(new UsersListResponce()
            {
                Users = users.ToList()
            });
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserDetails([FromRoute] Guid id)
        {
            try
            {
                var user = _usersProvider.GetUserInfo(id);
                return Ok(user); // 200
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());

                return NotFound(ex.Message);
                // return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUserInfo([FromRoute] Guid id, UpdateUserBody body)
        {
            try
            {
                var user = _usersManager.UpdateUser(id, _mapper.Map<UpdateUserModel>(body));

                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());

                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] Guid id)
        {
            try
            {
                _usersManager.DeleteUser(id);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());

                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult GetFilteredUsers([FromQuery] UserFilter filter)
        {
            var users = _usersProvider.GetAllUsersWithFilter(_mapper.Map<UserModelFilter>(filter));

            return Ok(new UsersListResponce()
            {
                Users = users.ToList()
            });
        }

    }
}
