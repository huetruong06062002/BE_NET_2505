using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BE_2505.Common.Netcore;
using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DBContext;
using BE_2505.DataAccess.Netcore.DTO;


namespace BE_2505.DataAccess.Netcore.DALImpl
{
	public class AccountDAOImpl : IAccountDAO
	{
		BE_25_05_DbContext _context;

		public AccountDAOImpl(BE_25_05_DbContext context)
		{
			_context = context;
		}

		public async Task<int> AccountLogin_UpdateRefreshToken(AccountLogin_UpdateRefreshTokenRequestData requestData)
		{
			try
			{
				var user = _context.account.Where(s => s.ID == requestData.UserId).FirstOrDefault();
				if (user == null || user.ID <= 0)
				{					
					return -1;
				}

				user.RefreshToken = requestData.RefreshToken;
				user.RefreshTokenExpriredTime = requestData.RefreshTokenExpiryTime;

				_context.account.Update(user);

				return _context.SaveChanges();
			}
			catch (Exception)
			{

				return -969;
			}

		}

		public async Task<AccountLoginResponseData> Login(AccountLoginRequestData requestData)
		{

			var returnData = new AccountLoginResponseData();

			try
			{
				var passwordHash = BE_2505.Common.Netcore.Security.ComputeSha256Hash(requestData.Password);

				var account = _context.account.Where(s => s.UserName == requestData.UserName 
					&& s.Password == passwordHash).FirstOrDefault();

				if(account == null || account.ID <= 0)
				{
					returnData.ResponseData = -1;
					returnData.ResponseMessenger = "Invalid username or password";

					return returnData;
				}


				returnData.ResponseData = 1;
				returnData.ResponseMessenger = "Login Success";

				returnData.account = account;

				return returnData;
			}
			catch (Exception)
			{

				throw;
			}

			return returnData;
		}


	}
}
