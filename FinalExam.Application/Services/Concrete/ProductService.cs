﻿using FinalExam.Application.DTOs;
using FinalExam.Application.Services.Abstract;
using FinalExam.Domain.Models;
using FinalExam.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Application.Services.Concrete
{
	public class ProductService : IProductService
	{
		private readonly DataContext _context;

		public ProductService(DataContext context)
		{
			this._context = context;
		}

		public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
		{
			var response = new ServiceResponse<List<Product>>()
			{
				Data = await _context.Products
					.Include(p => p.Variants)
					.ToListAsync()
			};

			return response;
		}

		// Interface implementation
		public async Task<ServiceResponse<Product>> GetProductsAsync(int productId)
		{
			var response = new ServiceResponse<Product>();
			var product = await _context.Products
				.Include(p => p.Variants)
				.ThenInclude(v => v.ProductType)
				.FirstOrDefaultAsync(p => p.Id == productId);
			if (product == null)
			{
				response.Success = false;
				response.Message = "Sorry, but this product does not exist.";
			}
			else
			{
				response.Data = product;
			}

			return response;
		}

		public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
		{
			var response = new ServiceResponse<List<Product>>()
			{
				Data = await _context.Products
					.Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
					.Include(p => p.Variants)
					.ToListAsync()
			};

			return response;
		}

		public async Task<ServiceResponse<ProductSearchResult>> SearchProductsAsync(string searchText, int page)
		{
			var pageResults = 2f;
			var pageCount = Math.Ceiling((await FindProductsBySearchText(searchText)).Count / pageResults);
			var products = await _context.Products
									.Where(p => p.Title.ToLower().Contains(searchText.ToLower()) ||
										   p.Description.ToLower().Contains(searchText.ToLower()))
									.Include(p => p.Variants)
									.Skip((page - 1) * (int)pageResults)
									.Take((int)pageResults)
									.ToListAsync();

			var response = new ServiceResponse<ProductSearchResult>()
			{
				Data = new ProductSearchResult
				{
					Products = products,
					CurrentPage = page,
					Pages = (int)pageCount
				}
			};

			return response;
		}

		public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestionsAsync(string searchText)
		{
			var products = await FindProductsBySearchText(searchText);

			List<string> result = new List<string>();

			foreach (var product in products)
			{
				// Suggest based on title
				if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
					result.Add(product.Title);

				// Suggest based on description
				if (product.Description != null)
				{
					// Remove punctutation for searching
					var punctuation = product.Description.Where(char.IsPunctuation)
						.Distinct().ToArray();
					var words = product.Description.Split()
						.Select(s => s.Trim(punctuation));

					foreach (var word in words)
					{
						if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase) &&
							!result.Contains(word))
						{
							result.Add(word);
						}
					}
				}
			}

			return new ServiceResponse<List<string>>()
			{
				Data = result
			};

		}

		public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
		{
			var response = new ServiceResponse<List<Product>>
			{
				Data = await _context.Products
					.Where(p => p.Featured)
					.Include(p => p.Variants)
					.ToListAsync()
			};

			return response;
		}

		// Private helpers
		private Task<List<Product>> FindProductsBySearchText(string searchText)
		{
			return _context.Products
								.Where(p => p.Title.ToLower().Contains(searchText.ToLower()) ||
									   p.Description.ToLower().Contains(searchText.ToLower()))
								.Include(p => p.Variants)
								.ToListAsync();
		}

	}
}
