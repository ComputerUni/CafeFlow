using AutoMapper;
using CafeFlow.Business.Abstract;
using CafeFlow.DataAccess.Repositories.Products;
using CafeFlow.DTO.Product;
using CafeFlow.DTO.ProductDetail;
using CafeFlow.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Concrete
{
    public class ProductService(IProductRepository _productRepository, IMapper _mapper) : IProductService
    {
        public async Task CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepository.CreateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            await _productRepository.DeleteAsync(product);
        }

        public async Task<List<ProductListDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllWithCategoryAsync();
            return _mapper.Map<List<ProductListDto>>(products);
        }

        public async Task<List<ProductListDto>> GetAllForMenuAsync()
        {
            var products = await _productRepository.GetAllForMenuAsync();
            return _mapper.Map<List<ProductListDto>>(products);
        }

        public async Task<UpdateProductDto> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateProductDto>(product);
        }

        public async Task<List<ProductListDto>> GetFeaturedProductsAsync()
        {
            var products = await _productRepository.GetFeaturedProductsAsync();
            return _mapper.Map<List<ProductListDto>>(products);
        }

        public async Task<ResultProductDetailDto> GetProductWithCategoryByIdAsync(int id)
        {
            var product = await _productRepository.GetProductWithCategoryByIdAsync(id);
            return _mapper.Map<ResultProductDetailDto>(product);
        }

        public async Task UpdateAsync(UpdateProductDto dto)
        {
            var product = await _productRepository.GetByIdAsync(dto.Id);
            _mapper.Map(dto, product);
            await _productRepository.UpdateAsync(product);
        }
    }
}
