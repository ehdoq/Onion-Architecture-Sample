using Application.Models.User;
using Application.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] AddUserDto addUser)
        {
            var user = _userService.Register(addUser);

            if (user != null)
                return StatusCode(StatusCodes.Status201Created);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
