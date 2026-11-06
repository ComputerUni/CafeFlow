using CafeFlow.Business.Abstract;
using CafeFlow.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._MenuLayoutViewComponents
{
    public class _MenuLayoutScriptViewComponent(IProductService _productService, ICategoryService _categoryService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new MenuPageViewModel
            {
                Products = await _productService.GetAllForMenuAsync(),
                Categories = await _categoryService.GetAllAsync()
            };
            return View(vm);
        }
    }
}
