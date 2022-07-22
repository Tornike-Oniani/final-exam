using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			this._productService = productService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Product>>>> Get()
		{
			var result = await _productService.GetProductsAsync();
			return Ok(result);
		}
	}
}
