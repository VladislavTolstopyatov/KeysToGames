using AutoMapper;
using Azure.Core;
using KeysToGames.BL.Auth;
using KeysToGames.BL.Auth.Entities;
using KeysToGames.BL.Users;
using KeysToGames.BL.Users.Entities;
using KeysToGames.Controllers.Users.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeysToUsers.Controllers.Users
{
    [ApiController]
    [Route("controller")]
    public class UsersController : ControllerBase
    {

        private readonly IAuthProvider _authProvider;
        private readonly IUsersManager _usersManager;
        private readonly IUsersProvider _usersProvider;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UsersController(IUsersManager usersManager, IUsersProvider usersProvider, IMapper mapper, ILogger logger,IAuthProvider authProvider)
        {
            _usersManager = usersManager;
            _usersProvider = usersProvider;
            _mapper = mapper;
            _logger = logger;
            _authProvider = authProvider;
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> LoginUser([FromQuery] string login, [FromQuery] string password)
        {
            try
            {
                TokensResponse tokens = await _authProvider.AuthorizeUser(login, password);
                return Ok(tokens);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserBody body)
        {
            try
            {
                await _authProvider.RegisterUser(_mapper.Map<RegisterUserModel>(body));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _usersProvider.GetAllUsers();

            return Ok(new UsersListResponce()
            {
                Users = users.ToList()
            });
        }

        [Authorize]
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


        [Authorize]
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

        [Authorize]
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

        [Authorize]
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
