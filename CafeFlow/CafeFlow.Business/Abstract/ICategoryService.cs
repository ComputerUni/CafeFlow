using CafeFlow.DTO.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryListDto>> GetAllAsync();
        Task<UpdateCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCategoryDto dto);
        Task UpdateAsync(UpdateCategoryDto dto);
        Task DeleteAsync(int id);
    }
}
