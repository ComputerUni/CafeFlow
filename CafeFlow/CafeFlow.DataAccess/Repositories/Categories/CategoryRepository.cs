using CafeFlow.DataAccess.Context;
using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.DTO.Category;
using CafeFlow.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Categories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetCategoriesWithCountsAsync()
        {
            return await _context.Categories.Where(c => !c.IsDeleted).OrderBy(c => c.CreatedAt).Include(c => c.Products).ThenInclude(p => p.OrderDetails).ToListAsync();
                
        }

        public async Task<List<Category>> GetCategoriesWithProductAsync()
        {
            return await _context.Categories.Where(c => !c.IsDeleted).Include(c => c.Products).OrderBy(c => c.Id).Take(4).ToListAsync();
        }
    }
}
