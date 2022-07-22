using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly DataContext _context;

		public ProductController(DataContext context)
		{
			this._context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var products = await _context.Products.ToListAsync();
			return Ok(products);
		}
	}
}
