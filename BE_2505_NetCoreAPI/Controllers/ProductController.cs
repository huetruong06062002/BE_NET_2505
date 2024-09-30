
using BE_2505.DataAccess.Netcore.DAL;
using BE_2505.DataAccess.Netcore.DTO;
using BE_2505.DataAccess.Netcore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace BE_2505_NetCoreAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

   //     private readonly IProductRepository _productRepository;

   //     public ProductController(IProductRepository productRepository)
   //     {
			//_productRepository = productRepository;
   //     }

        private readonly IUnitOfWork_BE_2505 _unitOfWork;

        public ProductController(IUnitOfWork_BE_2505 unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}
        [HttpPost("GetProduct")]
        public async Task<ActionResult> GetProduct(ProductGetListRequestData requestData)
        {
            try
            {
                var list = await _unitOfWork._productRepository.GetProduct(requestData);
                return Ok(list);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("ProductInsertUpdate")]
        public async Task<ActionResult> GetProduct(Product requestData)
        {
            try
            {
				var list = await _unitOfWork._productRepository.ProductInsertUpdate(requestData, 1);
				return Ok(list);
			}
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
