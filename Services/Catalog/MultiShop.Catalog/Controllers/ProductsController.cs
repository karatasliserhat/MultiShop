﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            return Ok(await _ProductService.GetAllProductAsync());
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            return Ok(await _ProductService.GetProductsWithCategoryAsync());
        }
        [HttpGet("[Action]/{categoryId}")]
        public async Task<IActionResult> ProductListWithCategoryByCategoryId(string categoryId)
        {
            return Ok(await _ProductService.GetProductsWithCategoryByCategoryId(categoryId));
        }
        [HttpGet("[Action]/{productId}")]
        public async Task<IActionResult> GetProductWithCategoryWithImagesWithDetailByProductId(string productId)
        {
            return Ok(await _ProductService.GetProductWithCategoryWithImagesWithDetailByProductIdAsync(productId));
        }
        [HttpGet("[Action]/{productId}")]
        public async Task<IActionResult> GetProductWithDetailByProductId(string productId)
        {
            return Ok(await _ProductService.GetProductWithWithDetailByProductIdAsync(productId));
        }
        [HttpGet("[Action]/{productId}")]
        public async Task<IActionResult> GetProductWithImagesByProductId(string productId)
        {
            return Ok(await _ProductService.GetProductWithWithImagesByProductIdAsync(productId));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            return Ok(await _ProductService.GetByIdProductAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _ProductService.CreateProductAsync(createProductDto);
            return Ok("Ürün Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _ProductService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _ProductService.DeleteProductAsync(id);
            return Ok("Ürün Silindi");

        }
    }
}
