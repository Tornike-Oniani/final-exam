namespace FinalExam.Client.Models
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
