using Blazored.LocalStorage;

namespace FinalExam.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;

        public CartService(ILocalStorageService localStorage, HttpClient http)
        {
            this._localStorage = localStorage;
            this._http = http;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItemViewModel cartItem)
        {
            List<CartItemViewModel> cart = await GetOrSetCartStorage();

            // Add item to cart or if it already exists increase its quantity
            var sameItem = cart.Find(i => i.ProductId == cartItem.ProductId && i.ProductTypeId == cartItem.ProductTypeId);
            if (sameItem == null)
                cart.Add(cartItem);
            else
                sameItem.Quantity += cartItem.Quantity;

            await _localStorage.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }

        public async Task<List<CartItemViewModel>> GetCartItems()
        {
            List<CartItemViewModel> cart = await GetOrSetCartStorage();

            return cart;
        }

        public async Task<List<CartProductResponseViewModel>> GetCartProducts()
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItemViewModel>>("cart");
            var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);
            var cartProducts = await response.Content.ReadFromJsonAsync<ServiceResponseViewModel<List<CartProductResponseViewModel>>>();
            return cartProducts.Data;
        }

        public async Task RemoveProductFromCart(int productId, int productTypeId)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItemViewModel>>("cart");
            if (cart == null)
                return;

            var cartItem = cart.Find(i => i.ProductId == productId && i.ProductTypeId == productTypeId);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
                await _localStorage.SetItemAsync("cart", cart);
                OnChange.Invoke();
            }
        }

        public async Task UpdateQuantity(CartProductResponseViewModel product)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItemViewModel>>("cart");
            if (cart == null)
                return;

            var cartItem = cart.Find(i => i.ProductId == product.ProductId && i.ProductTypeId == product.ProductTypeId);
            if (cartItem != null)
            {
                cartItem.Quantity = product.Quantity;
                await _localStorage.SetItemAsync("cart", cart);
            }
        }

        // Private helpers
        private async Task<List<CartItemViewModel>> GetOrSetCartStorage()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItemViewModel>>("cart");
            if (cart == null)
                cart = new List<CartItemViewModel>();
            return cart;
        }

    }
}
