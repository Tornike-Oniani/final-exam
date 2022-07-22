namespace FinalExam.Client.Services.ProductService
{
	public interface IProductService
	{
		List<ProductViewModel> Products { get; set; }
		Task GetProducts();
		Task<ServiceResponseViewModel<ProductViewModel>> GetProduct(int productId);
	}
}
