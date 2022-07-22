namespace FinalExam.Client.Services.CategoryService
{
	public interface ICategoryService
	{
		List<CategoryViewModel> Categories { get; set; }
		Task GetCategories();
	}
}
