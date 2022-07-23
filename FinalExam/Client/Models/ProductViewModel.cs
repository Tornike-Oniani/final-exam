namespace FinalExam.Client.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public CategoryViewModel? Category { get; set; }
        public int CategoryId { get; set; }
        public bool Featured { get; set; } = false;
        public List<ProductVariantViewModel> Variants { get; set; } = new List<ProductVariantViewModel>();
    }
}
