﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505_Common
{
	public class Bird : Animal
	{
		public override string Eat()
		{
			return "thóc";
		}

		public override string Sound()
		{
			return "chíp chíp";
		}

		public override string Sound2()
		{
			return "chíp chíp2w";
		}

	}

}
