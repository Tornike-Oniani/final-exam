using FinalExam.Domain.Models;

namespace FinalExam.Domain.Services
{
	public interface IProductService
	{
		Task<ServiceResponse<List<Product>>> GetProductsAsync();
	}
}
