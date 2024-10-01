using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BE_2505_NetCoreAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{

		private IAccountDAO _accountDAO;
		private IConfiguration _configuration;

		public AccountController(IAccountDAO accountDAO, IConfiguration configuration)
		{
			_accountDAO = accountDAO;
			_configuration = configuration;
		}

		[HttpPost("login")]

		public async Task<IActionResult> Login(AccountLoginRequestData requestData)
		{

			var returnData = new AccountLoginResponseData();
			try
			{
				//Bước 1: Login
				if (requestData == null 
					|| string.IsNullOrEmpty(requestData.UserName)
					|| string.IsNullOrEmpty(requestData.Password)
					)
				{
					returnData.ResponseData = 1;
					returnData.ResponseMessenger = "Dữ liệu đầu vào không hợp lệ!";
					return Ok(returnData);
				}
				var rs = await _accountDAO.Login(requestData);

				if(rs.ResponseData <= 0)
				{
					returnData.ResponseData = 1;
					returnData.ResponseMessenger = "Invalid username or password";
					return Ok(returnData);
				}

				rs.account.Password = string.Empty;


				//Bước 2: Tạo token và trả về client

				//Bước 2.1: Tạo list claim để lưu thông tin account
				var authClaims = new List<Claim> { 
					new Claim(ClaimTypes.Name, rs.account.UserName), 
					new Claim(ClaimTypes.PrimarySid, rs.account.ID.ToString()),
				};

				//Bước 2.2: Tạo Token từ claims
				var newToken = CreateToken(authClaims);

				//Bước 2.2.1 Tạo refreshToken và lưu vào db

				var RefreshTokenValidityInDays = _configuration["JWT:RefreshTokenValidityInDays"] ?? "";

				var refeshtoken = GenerateRefreshToken();

				var req = new AccountLogin_UpdateRefreshTokenRequestData
				{
					 UserId = rs.account.ID,

					 RefreshToken = refeshtoken,

					 RefreshTokenExpiryTime = DateTime.Now.AddDays(int.Parse(RefreshTokenValidityInDays))
				};
				var res = _accountDAO.AccountLogin_UpdateRefreshToken(req);
				//Bước 2.3: Trả về client


				returnData.ResponseData = 1;
				returnData.ResponseMessenger = "Invalid username or password";
				returnData.token = new JwtSecurityTokenHandler().WriteToken(newToken);
				returnData.account = rs.account;
				return Ok(returnData);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			using var rng = RandomNumberGenerator.Create();
			rng.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}
		private JwtSecurityToken CreateToken(List<Claim> authClaims)
		{
			var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
			_ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

			var token = new JwtSecurityToken(
				issuer: _configuration["JWT:ValidIssuer"],
				audience: _configuration["JWT:ValidAudience"],
				expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
				claims: authClaims,
				signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
				);

			return token;
		}

	}
}
