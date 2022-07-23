using FinalExam.Application.DTOs;
using FinalExam.Domain.Models;

namespace FinalExam.Application.Services.Abstract
{
	public interface ICategoryService
	{
		Task<ServiceResponse<List<Category>>> GetCategoriesAsync();
	}
}
