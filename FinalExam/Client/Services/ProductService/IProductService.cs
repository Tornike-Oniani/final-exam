namespace FinalExam.Client.Services.ProductService
{
	public interface IProductService
	{
		event Action ProductsChanged;
		List<ProductViewModel> Products { get; set; }
		Task GetProducts(string? categoryUrl = null);
		Task<ServiceResponseViewModel<ProductViewModel>> GetProduct(int productId);
	}
}
