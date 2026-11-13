using CafeFlow.Business.Abstract;
using CafeFlow.Business.Concrete;
using CafeFlow.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CafeFlow.WebUI.ViewComponents._MenuLayoutViewComponents
{
    public class _MenuLayoutScriptViewComponent(IProductService _productService, ICategoryService _categoryService, IFavoriteService _favoriteService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HashSet<int> favoriteIds = [];
            if (HttpContext.User.Identity?.IsAuthenticated == true)
            {
                var userId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                favoriteIds = await _favoriteService.GetUserFavoriteProductIdsAsync(userId);
            }

            ViewBag.FavoriteProductIds = favoriteIds;

            var vm = new MenuPageViewModel
            {
                Products = await _productService.GetAllForMenuAsync(),
                Categories = await _categoryService.GetAllAsync(),
                FavoriteProductIds = favoriteIds
            };
            return View(vm);
        }
    }
}
