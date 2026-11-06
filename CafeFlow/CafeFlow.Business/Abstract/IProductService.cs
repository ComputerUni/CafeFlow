using CafeFlow.DTO.Product;

namespace CafeFlow.Business.Abstract
{
    public interface IProductService
    {
        Task<List<ProductListDto>> GetAllAsync();
        Task<List<ProductListDto>> GetFeaturedProductsAsync();
        Task<UpdateProductDto> GetByIdAsync(int id);
        Task CreateAsync(CreateProductDto dto);
        Task UpdateAsync(UpdateProductDto dto);
        Task DeleteAsync(int id);
    }
}
