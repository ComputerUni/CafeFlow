using CafeFlow.Business.Abstract;
using CafeFlow.Business.Concrete;
using CafeFlow.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CafeFlow.WebUI.ViewComponents._ProductDetailLayoutViewComponents
{
    public class _ProductDetailLayoutScriptsViewComponent(IFavoriteService _favoriteService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ProductDetailPageViewModel model)
        {
            HashSet<int> favoriteIds = [];
            if (HttpContext.User.Identity?.IsAuthenticated == true)
            {
                var userId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                favoriteIds = await _favoriteService.GetUserFavoriteProductIdsAsync(userId);
            }

            ViewBag.FavoriteProductIds = favoriteIds;

            return View(model);
        }
    }
}
