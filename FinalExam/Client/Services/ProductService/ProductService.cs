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
			var result = await _http.GetFromJsonAsync<ServiceResponseViewModel<List<ProductViewModel>>>("api/Product");
			if (result != null && result.Data != null)
				Products = result.Data;
		}
	}
}
