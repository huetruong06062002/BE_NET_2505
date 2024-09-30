
using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DTO;

namespace BE_2505.DataAccess.Netcore.UnitOfWork
{
	public interface IUnitOfWork_BE_2505
	{
		public IProductRepository _productRepository { get; set; }
		IProductGenericRepository _productGenericRepository { get; set; }
		int SaveChanges();


	}
}
