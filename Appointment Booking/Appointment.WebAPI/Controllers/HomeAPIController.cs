using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Appointment.ModelView;
using Appointment.BusinessLayer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Appointment.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeAPIController : ControllerBase
    {
        private IBusiness _business;
        private IConfiguration _configuration;

        public HomeAPIController(IBusiness business,IConfiguration configuration)
        {
            _business = business;
            _configuration = configuration;
        }

        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials=new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var token =new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],null,
                expires:DateTime.Now.AddMinutes(60),
                signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
  
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] SignUpModel newUser)
        {
            return Ok(await _business.Register(newUser));

        }

        [HttpPost]
        public IActionResult IsValidUser(LogInModel user)
        {
            int userId = _business.IsValidUser(user);
            if (userId != -1)
            {
                string token = GenerateToken();
                return Ok(new { UserId = userId, Token = token });
            }
            return Unauthorized();
        }

        [HttpGet]
        public IActionResult IsEmailExists(string email)
        {
            return Ok(_business.IsEmailExists(email));
        }

    }
}
