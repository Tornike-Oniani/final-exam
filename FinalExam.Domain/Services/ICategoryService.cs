using FinalExam.Domain.Models;

namespace FinalExam.Domain.Services
{
	public interface ICategoryService
	{
		Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
	}
}
