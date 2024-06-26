﻿using MultiShop.Catalog.Dtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<GetByIdProductDto> GetByIdProductAsync(string productId);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string productId);

        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync();

        Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryByCategoryId(string categoryId);

        Task<ProductsWithCategoryWithImagesWithDetailDto> GetProductWithCategoryWithImagesWithDetailByProductIdAsync(string productId);
        Task<GetProductWithProductImagesDto> GetProductWithWithImagesByProductIdAsync(string productId);
        Task<GetProductWithProductDetailDto> GetProductWithWithDetailByProductIdAsync(string productId);
    }
}
