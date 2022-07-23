using FinalExam.Application.DTOs;

namespace FinalExam.Application.Services.Abstract
{
	public interface ICartService
	{
		Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(List<CartItem> cartItems);
	}
}
