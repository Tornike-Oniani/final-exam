using FinalExam.Domain.Models;

namespace FinalExam.Domain.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductsAsync(int productId);
        Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl);
        Task<ServiceResponse<List<Product>>> SearchProductsAsync(string searchText);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestionsAsync(string searchText);
    }
}
