namespace FinalExam.Client.Models
{
    public class ProductVariantViewModel
    {
        public ProductViewModel Product { get; set; }
        public int ProductId { get; set; }
        public ProductTypeViewModel ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
    }
}
