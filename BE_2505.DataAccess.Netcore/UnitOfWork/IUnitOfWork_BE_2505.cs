using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.DataAccess.Netcore.DAL;

namespace BE_2505.DataAccess.Netcore.UnitOfWork
{
	public interface IUnitOfWork_BE_2505
	{
		public IProductRepository _productRepository { get; set; };

		int SaveChanges();


	}
}
