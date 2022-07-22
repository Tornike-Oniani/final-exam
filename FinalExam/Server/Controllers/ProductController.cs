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
	}
}