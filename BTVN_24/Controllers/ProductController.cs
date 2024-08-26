using BTVN_24.UniOfWork.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTVN_24.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[Authorize]
		[HttpGet("getall")]
		public async Task<IActionResult> GetAll()
		{
			var products = await _unitOfWork.Products.GetAllAsync();
			if (products == null || !products.Any())
			{
				return NotFound("No products found.");
			}
			return Ok(products);
		}
	}
}
