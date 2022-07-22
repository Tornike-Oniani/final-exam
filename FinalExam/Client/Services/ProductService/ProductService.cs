namespace FinalExam.Client.Services.ProductService
{
	public class ProductService : IProductService
	{
		private readonly HttpClient _http;

		public ProductService(HttpClient http)
		{
			this._http = http;
		}

		public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

		public async Task GetProducts()
		{
			var result = await _http.GetFromJsonAsync<ServiceResponseViewModel<List<ProductViewModel>>>("api/product");
			if (result != null && result.Data != null)
				Products = result.Data;
		}
		public async Task<ServiceResponseViewModel<ProductViewModel>> GetProduct(int productId)
		{
			var result = await _http.GetFromJsonAsync<ServiceResponseViewModel<ProductViewModel>>($"api/product/{productId}");
			return result;
		}
	}
}
