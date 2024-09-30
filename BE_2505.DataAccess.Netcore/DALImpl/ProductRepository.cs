
using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DBContext;
using BE_2505.DataAccess.Netcore.DTO;

namespace BE_2505.DataAccess.Netcore.DALImpl
{
	public class ProductRepository : IProductRepository
	{
		private BE_25_05_DbContext  _context;

		public ProductRepository(BE_25_05_DbContext context)
		{
			_context = context;
		}

		public async Task<List<Product>> GetProduct(ProductGetListRequestData requestData)
		{
			var list = new List<Product>();

			try
			{
				list = _context.product.ToList();
				if (!string.IsNullOrEmpty(requestData.ProductName))
				{
					list = list.FindAll(s => s.ProductName.Contains(requestData.ProductName));
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}

			return list;
		}

		public async Task<ReturnData> ProductInsertUpdate(Product product, int CreaterUser)
		{

			var returnData = new ReturnData();
			try
			{
				if(product == null
					|| string.IsNullOrEmpty(product.ProductName) 
					||  !BE_2505.Common.Netcore.Validation.CheckXSSInput(product.ProductName) 
					|| product.Price <= 0
					|| string.IsNullOrEmpty(product.Image)
				)
				{
					returnData.ResponseData = -1;
					returnData.ResponseMessenger = "Dữ liệu đầu vào không hợp lệ";
					return returnData;
				}

				//Xử lý ảnh

				//Thêm mới
				if(product.ProductId == 0)
				{
					product.CreatedUser = 1;
					product.CreatedTime = DateTime.UtcNow.AddHours(7);
					_context.product.Add(product);

					var rs = _context.SaveChanges();

					if(rs <= 0)
					{
						returnData.ResponseData = -2;
						returnData.ResponseMessenger = "Thêm mới thất bại";
						return returnData;
					}

					returnData.ResponseData = 1;
					returnData.ResponseMessenger = "Thêm thành công";
					return returnData;
				}
				else
				{
					//cập nhật

					var productDB = _context.product.Where(s => s.ProductId == product.ProductId).FirstOrDefault();
					if(productDB == null || productDB.ProductId <= 0)
					{
						returnData.ResponseData = -3;
						returnData.ResponseMessenger = "Không tồn tại sản phẩm cần update trên hệ thống";
						return returnData;
					}

					productDB.ProductName = product.ProductName;
					productDB.Price = product.Price;

					_context.product.Update(productDB);

					var rs = _context.SaveChanges();
					if (rs <= 0)
					{
						returnData.ResponseData = -2;
						returnData.ResponseMessenger = "Cập nhật thất bại";
						return returnData;
					}

					returnData.ResponseData = 1;
					returnData.ResponseMessenger = "Cập nhật thành công";
					return returnData;
				}
			}
			catch (Exception)
			{

				throw;
			}

			return returnData;
		}
	}
}
