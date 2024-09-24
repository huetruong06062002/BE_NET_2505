using Microsoft.AspNetCore.Mvc;
using BE_2505.DataAccess.Netcore.DTO;
using BE_2505.DataAccess.Netcore.DALImpl;

namespace WebMVC_netCore.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult  Login()
		{
            return View();
        }

		public async Task<JsonResult> Account_Login([FromBody] AccountLoginRequestData requestData)
		{

			var returnData = new AccountLoginResponseData();

			try
			{

                var rs = await new AccountDAOImpl().Login(requestData);

                returnData.ResponseMessenger = rs.ResponseMessenger;
            }
			catch (Exception)
			{

               
			}

           return Json(returnData);
        }
	}
}
