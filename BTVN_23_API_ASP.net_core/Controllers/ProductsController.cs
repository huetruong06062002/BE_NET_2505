using BTVN_23_API_ASP.net_core.DTO;

using BTVN_23_API_ASP.net_core.Models;
using BTVN_23_API_ASP.net_core.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Threading.Tasks;

namespace BTVN_23_API_ASP.net_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _unitOfWork.Repository<Product>().GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProduct dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = new Product
            {
                Id = Guid.NewGuid().GetHashCode(),
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                IsActive = dto.IsActive
            };

            await _unitOfWork.Repository<Product>().AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            var existingProduct = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
            if (existingProduct == null) return NotFound();

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.IsActive = product.IsActive;

            _unitOfWork.Repository<Product>().Update(existingProduct);
            await _unitOfWork.CompleteAsync();
            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
            if (product == null) return NotFound();

            _unitOfWork.Repository<Product>().Remove(product);
            await _unitOfWork.CompleteAsync();
            return Ok(new { Message = "Product deleted successfully." });
        }
    }
}
