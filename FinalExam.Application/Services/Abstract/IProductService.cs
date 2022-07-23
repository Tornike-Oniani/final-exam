using FinalExam.Application.DTOs;
using FinalExam.Domain.Models;

namespace FinalExam.Application.Services.Abstract
{
	public interface IProductService
	{
		Task<ServiceResponse<List<Product>>> GetProductsAsync();
		Task<ServiceResponse<Product>> GetProductsAsync(int productId);
		Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl);
		Task<ServiceResponse<ProductSearchResult>> SearchProductsAsync(string searchText, int page);
		Task<ServiceResponse<List<string>>> GetProductSearchSuggestionsAsync(string searchText);
		Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
	}
}
