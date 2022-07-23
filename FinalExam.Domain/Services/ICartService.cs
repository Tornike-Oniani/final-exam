using FinalExam.Domain.Models;

namespace FinalExam.Domain.Services
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(List<CartItem> cartItems);
    }
}
