using CafeFlow.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._MenuLayoutViewComponents
{
    public class _MenuLayoutMenuSectionViewComponent(IProductService _productService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllForMenuAsync();
            return View(products);
        }
    }
}
