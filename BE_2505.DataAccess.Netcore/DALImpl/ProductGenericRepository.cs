
using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DBContext;
using BE_2505.DataAccess.Netcore.DTO;
using Microsoft.EntityFrameworkCore;

namespace BE_2505.DataAccess.Netcore.DALImpl
{
	public class ProductGenericRepository : GenericRepository<Product>, IProductGenericRepository
	{
		public ProductGenericRepository(BE_25_05_DbContext context) : base(context)
		{
		}
	}
}
