using BE_2505_NetCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_2505_NetCoreAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetListProduct")]
        public async Task<ActionResult> GetListProduct()
        {
            var products = _productService.GetListProduct();
            return Ok(products);
        }
    }
}
