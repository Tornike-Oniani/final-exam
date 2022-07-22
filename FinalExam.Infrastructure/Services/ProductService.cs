using FinalExam.Domain.Models;
using FinalExam.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Infrastructure.Services
{
	public class ProductService : IProductService
	{
		private readonly DataContext _context;

		public ProductService(DataContext context)
		{
			this._context = context;
		}

		public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
		{
			var response = new ServiceResponse<List<Product>>()
			{
				Data = await _context.Products.ToListAsync()
			};

			return response;
		}
	}
}
