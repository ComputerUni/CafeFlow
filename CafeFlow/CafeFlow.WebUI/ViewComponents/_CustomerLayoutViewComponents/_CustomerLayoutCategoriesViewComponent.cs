using CafeFlow.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._CustomerLayoutViewComponents
{
    public class _CustomerLayoutCategoriesViewComponent(ICategoryService _categoryService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetCategoriesWithProductAsync();
            var result = categories.Take(4).ToList();
            return View(result);
        }
    }
}
