using FinalExam.Domain.Models;
using FinalExam.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Infrastructure.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly DataContext _context;

		public CategoryService(DataContext context)
		{
			this._context = context;
		}

		public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
		{
			var categories = await _context.Categories.ToListAsync();
			return new ServiceResponse<List<Category>>()
			{
				Data = categories
			};
		}
	}
}
