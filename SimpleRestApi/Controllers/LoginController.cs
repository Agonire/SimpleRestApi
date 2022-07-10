using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleRestApi.Models;
using SimpleRestApi.Options;
using SimpleRestApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SimpleRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;
        public LoginController(ILogger<WeatherForecastController> logger, IUserService userService, IOptions<JwtSettings> jwtSettings)
        {
            _logger = logger;
            _userService = userService;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<string> Login(LoginRequest request)
        {
            var authenticatedUser = _userService.Authenticate(request.Username, request.Password);

            if (authenticatedUser is null)
                return Unauthorized();

            var jwt = CreateToken(authenticatedUser);

            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }
        private JwtSecurityToken CreateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Claims
            var claims = new List<Claim>()
            {
                new Claim("sub", user.Username),
            };

            return new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(3),
                signingCredentials);
        }
    }
}