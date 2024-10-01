using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.DataAccess.Netcore.DTO;

namespace BE_2505.DataAccess.Netcore.DAL
{
    public interface IAccountDAO
    {
        Task<AccountLoginResponseData> Login(AccountLoginRequestData requestData);

        Task<int> AccountLogin_UpdateRefreshToken(AccountLogin_UpdateRefreshTokenRequestData requestData) ;
    }
}
