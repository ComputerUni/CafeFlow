using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.DataAccess.Repositories.Products;
using CafeFlow.Entity;

namespace CafeFlow.Business.DesignPatterns.ChainOfResponsibility
{
    public class ProductAvailabilityHandler : OrderValidationHandler
    {
        private readonly IProductRepository _productRepository;

        public ProductAvailabilityHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task Validate(OrderValidationRequest request)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if(product == null || !product.IsActive)
            {
                throw new Exception("Ürün mevcut değil veya aktif değil.");
            }

            if (product.Stock <= 0)
            {
                throw new Exception($"'{product.Name}' tükendi, stokta kalmadı.");
            }

            if (product.Stock < request.Quantity)
            {
                throw new Exception($"'{product.Name}' için yeterli stok bulunmuyor. (Mevcut stok: {product.Stock})");
            }

            if (NextHandler != null)
            {
                await NextHandler.Validate(request);
            }
        }
    }
}
