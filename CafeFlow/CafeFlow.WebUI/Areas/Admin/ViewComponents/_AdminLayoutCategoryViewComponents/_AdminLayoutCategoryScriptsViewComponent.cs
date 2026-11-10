using CafeFlow.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Areas.Admin.ViewComponents._AdminLayoutCategoryViewComponents
{
    public class _AdminLayoutCategoryScriptsViewComponent(ICategoryService _categoryService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetCategoriesWithCountsAsync();
            return View(categories);
        }
    }
}
