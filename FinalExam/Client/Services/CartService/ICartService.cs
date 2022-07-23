namespace FinalExam.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItemViewModel cartItem);
        Task<List<CartItemViewModel>> GetCartItems();
        Task<List<CartProductResponseViewModel>> GetCartProducts();
        Task RemoveProductFromCart(int productId, int productTypeId);
        Task UpdateQuantity(CartProductResponseViewModel product);
    }
}
