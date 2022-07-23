﻿using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await _productService.GetProductsAsync();
            return Ok(result);
        }
        [HttpGet("{productId:int}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {
            var result = await _productService.GetProductsAsync(productId);
            return Ok(result);
        }
        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
            var result = await _productService.GetProductsByCategoryAsync(categoryUrl);
            return Ok(result);
        }
        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<ServiceResponse<Product>>> SearchProducts(string searchText)
        {
            var result = await _productService.SearchProductsAsync(searchText);
            return Ok(result);
        }
        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<Product>>> SearchSuggestions(string searchText)
        {
            var result = await _productService.GetProductSearchSuggestionsAsync(searchText);
            return Ok(result);
        }
    }
}
