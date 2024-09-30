using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DBContext;
using BE_2505.DataAccess.Netcore.DTO;

namespace BE_2505.DataAccess.Netcore.DALImpl
{
	public class CategoryGenericRepository : GenericRepository<Category>, ICategoryGenericRepository
	{
		public CategoryGenericRepository(BE_25_05_DbContext context) : base(context)
		{
		}
	}
}
