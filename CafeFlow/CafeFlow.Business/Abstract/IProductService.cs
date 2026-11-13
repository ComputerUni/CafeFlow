using CafeFlow.DTO.Product;
using CafeFlow.DTO.ProductDetail;
using CafeFlow.Entity;

namespace CafeFlow.Business.Abstract
{
    public interface IProductService
    {
        Task<List<ProductListDto>> GetAllAsync();
        Task<List<ProductListDto>> GetFeaturedProductsAsync();
        Task<List<ProductListDto>> GetAllForMenuAsync();
        Task<UpdateProductDto> GetByIdAsync(int id);
        Task CreateAsync(CreateProductDto dto);
        Task UpdateAsync(UpdateProductDto dto);
        Task DeleteAsync(int id);
        Task<ResultProductDetailDto> GetProductWithCategoryByIdAsync(int id);
        Task ChangeActiveAsync(int id);
        Task ChangeFeatureAsync(int id);
        Task ChangeCustomizableAsync(int id);
    }
}
