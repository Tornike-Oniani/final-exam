namespace FinalExam.Client.Services.CategoryService
{
	public class CategoryService : ICategoryService
	{
		private readonly HttpClient _http;

		public CategoryService(HttpClient http)
		{
			this._http = http;
		}

		public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

		public async Task GetCategories()
		{
			var response = await _http.GetFromJsonAsync<ServiceResponseViewModel<List<CategoryViewModel>>>("api/category");
			if (response != null && response.Data != null)
				Categories = response.Data;
		}
	}
}
