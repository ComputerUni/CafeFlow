using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.ChainOfResponsibility
{
    public class ProductAvailabilityHandler : OrderValidationHandler
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductAvailabilityHandler(IGenericRepository<Product> productRepository)
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

            if(product.Stock < request.Quantity)
            {
                throw new Exception("Yeterli miktarda ürün stoğu yok.");
            }

            if(NextHandler != null)
            {
                await NextHandler.Validate(request);
            }
        }
    }
}
