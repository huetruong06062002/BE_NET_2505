﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DTO
{
	public class Account
	{
		public int ID {get;set;}
		public string UserName{get;set;}
		public string Password{get;set;}
		public string FullName { get; set; }

		public string RefreshToken { get; set; }

		public DateTime RefreshTokenExpriredTime { get; set; }
	}
}
