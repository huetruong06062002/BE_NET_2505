﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DTO
{
    public class AccountLoginRequestData
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }


    public class AccountLoginResponseData : ReturnData
    {
        public Account account { get; set; }

        public string token { get; set; }
    }

    public class AccountLogin_UpdateRefreshTokenRequestData
    {
        public int UserId { get; set; }
        
        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }


}
