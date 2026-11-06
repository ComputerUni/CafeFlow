using CafeFlow.DataAccess.Context;
using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Products
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetAllWithCategoryAsync()
        {
            return await _context.Products.Include(x => x.Category).Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<List<Product>> GetFeaturedProductsAsync()
        {
            return await _context.Products.Include(x => x.Category).Where(x => x.IsFeatured).Take(9).ToListAsync();
        }
    }
}
