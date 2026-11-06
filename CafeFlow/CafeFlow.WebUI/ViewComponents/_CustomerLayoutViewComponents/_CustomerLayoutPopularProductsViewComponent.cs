using CafeFlow.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._CustomerLayoutViewComponents
{
    public class _CustomerLayoutPopularProductsViewComponent(IProductService _productService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetFeaturedProductsAsync();
            return View(products);
        }
    }
}
