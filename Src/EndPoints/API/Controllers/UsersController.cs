using Application.Models.User;
using Application.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        private string GenerateJSONWebToken(string mobile)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] 
            {
                new Claim(JwtRegisteredClaimNames.NameId, mobile),
                new Claim(JwtRegisteredClaimNames.UniqueName, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] AddUserDto addUser)
        {
            var user = _userService.Register(addUser);

            if (user != null)
                return StatusCode(StatusCodes.Status201Created);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUserDto loginUser)
        {
            if (_userService.Login(loginUser))
            {
                var tokenString = GenerateJSONWebToken(loginUser.Mobile);

                return Ok(new 
                { 
                    token = tokenString 
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
