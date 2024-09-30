using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.DataAccess.Netcore.DTO;

namespace BE_2505.DataAccess.Netcore.DAL
{
	public interface IProductRepository
	{
		Task<List<Product>> GetProduct(ProductGetListRequestData requestData);
		Task<ReturnData> ProductInsertUpdate(Product product, int CreaterUser);
	}
}
