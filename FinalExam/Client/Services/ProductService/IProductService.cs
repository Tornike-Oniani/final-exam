namespace FinalExam.Client.Services.ProductService
{
	public interface IProductService
	{
		List<ProductViewModel> Products { get; set; }
		Task GetProducts();
	}
}
