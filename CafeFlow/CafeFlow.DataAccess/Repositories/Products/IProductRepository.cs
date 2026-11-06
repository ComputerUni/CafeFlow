using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Products
{
    public interface IProductRepository : IGenericRepository<Product> 
    {
        Task<List<Product>> GetAllWithCategoryAsync();
        Task<List<Product>> GetFeaturedProductsAsync();
        Task<List<Product>> GetAllForMenuAsync();
    }
}
