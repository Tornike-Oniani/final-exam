namespace FinalExam.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        List<ProductViewModel> Products { get; set; }
        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; }
        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponseViewModel<ProductViewModel>> GetProduct(int productId);
        Task SearchProducts(string serachText, int Page);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
    }
}
