using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.DTO.Category;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Categories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithProductAsync();
        Task<List<Category>> GetCategoriesWithCountsAsync();
    }
}
