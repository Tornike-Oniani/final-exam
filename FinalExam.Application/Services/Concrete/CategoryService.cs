using FinalExam.Application.DTOs;
using FinalExam.Application.Services.Abstract;
using FinalExam.Domain.Models;
using FinalExam.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Application.Services.Concrete
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
