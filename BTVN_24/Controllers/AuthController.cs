using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BTVN_24.Models;
using BTVN_24.Models.Dto;
using BTVN_24.UniOfWork.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BTVN_24.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IConfiguration _configuration;

		public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_configuration = configuration;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(UserRegister userRegister)
		{
			if ((await _unitOfWork.Users.GetAllAsync()).Any(u => u.Username == userRegister.Username))
				return BadRequest("Username already exists.");

			var user = new User
			{
				Username = userRegister.Username,
				Email = userRegister.Email,
				Password = BCrypt.Net.BCrypt.HashPassword(userRegister.Password)
			};

			await _unitOfWork.Users.AddAsync(user);
			await _unitOfWork.SaveChangesAsync();

			return Ok("User registered successfully");
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(UserLogin userLogin)
		{
			var user = (await _unitOfWork.Users.GetAllAsync()).SingleOrDefault(u => u.Username == userLogin.Username);

			if (user == null || !BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password))
				return Unauthorized("Invalid credentials");

			var token = GenerateJwtToken(user);
			return Ok(new { token });
		}

		private string GenerateJwtToken(User user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
			new Claim(JwtRegisteredClaimNames.Sub, user.Username),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
		};

			var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
			  _configuration["Jwt:Audience"],
			  claims,
			  expires: DateTime.Now.AddMinutes(30),
			  signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
