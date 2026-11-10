using AutoMapper;
using CafeFlow.Business.Abstract;
using CafeFlow.DataAccess.Repositories.Categories;
using CafeFlow.DTO.Category;
using CafeFlow.Entity;

namespace CafeFlow.Business.Concrete
{
    public class CategoryService(ICategoryRepository _categoryRepository, IMapper _mapper) : ICategoryService
    {
        public async Task CreateAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _categoryRepository.CreateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<List<CategoryListDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryListDto>>(categories);
        }

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateCategoryDto>(category);
        }

        public async Task<List<CategoryListDto>> GetCategoriesWithCountsAsync()
        {
            var categories = await _categoryRepository.GetCategoriesWithCountsAsync();
            return _mapper.Map<List<CategoryListDto>>(categories);
        }

        public async Task<List<CategoryListDto>> GetCategoriesWithProductAsync()
        {
            var categories = await _categoryRepository.GetCategoriesWithProductAsync();
            return _mapper.Map<List<CategoryListDto>>(categories);
        }

        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(dto.Id);
            _mapper.Map(dto, category);
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
