using FinalExam.Domain.Models;

namespace FinalExam.Domain.Services
{
	public interface IProductService
	{
		Task<ServiceResponse<List<Product>>> GetProductsAsync();
		Task<ServiceResponse<Product>> GetProductsAsync(int productId);
		Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl);
	}
}
