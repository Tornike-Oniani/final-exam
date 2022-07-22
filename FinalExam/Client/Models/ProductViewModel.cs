﻿namespace FinalExam.Client.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public decimal Price { get; set; }
    }
}
