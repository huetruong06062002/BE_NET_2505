using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DTO;
using BE_2505.Common.Netcore;

namespace BE_2505.DataAccess.Netcore.DALImpl
{
    public class AccountDAOImpl : IAccountDAO
    {
        public async Task<AccountLoginResponseData> Login(AccountLoginRequestData requestData)
        {

            var returnData = new AccountLoginResponseData();

			try
			{
				var passwordHash = Security.GetSaltedHash(requestData.Password);
                returnData.ResponseMessenger = passwordHash;

            }
			catch (Exception)
			{

				throw;
			}

			return returnData;
        }

    
    }
}
