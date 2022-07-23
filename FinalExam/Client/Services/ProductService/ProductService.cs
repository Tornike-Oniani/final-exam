namespace FinalExam.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            this._http = http;
        }

        public event Action ProductsChanged;

        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        public string Message { get; set; } = "Loading products...";

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
            await _http.GetFromJsonAsync<ServiceResponseViewModel<List<ProductViewModel>>>("api/product") :
            await _http.GetFromJsonAsync<ServiceResponseViewModel<List<ProductViewModel>>>($"api/product/category/{categoryUrl}");
            if (result != null && result.Data != null)
                Products = result.Data;

            ProductsChanged.Invoke();
        }
        public async Task<ServiceResponseViewModel<ProductViewModel>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponseViewModel<ProductViewModel>>($"api/product/{productId}");
            return result;
        }

        public async Task SearchProducts(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponseViewModel<List<ProductViewModel>>>($"api/product/search/{searchText}");
            if (result != null && result.Data != null)
                Products = result.Data;
            if (Products.Count == 0)
                Message = "No products found.";
            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponseViewModel<List<string>>>($"api/product/searchsuggestions/{searchText}");
            return result.Data;
        }
    }
}
