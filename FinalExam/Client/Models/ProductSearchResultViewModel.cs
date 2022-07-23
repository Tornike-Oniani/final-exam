namespace FinalExam.Client.Models
{
    public class ProductSearchResultViewModel
    {
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
