using CafeFlow.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CafeFlow.WebUI.Controllers
{
    [Authorize]
    public class FavoriteController(IFavoriteService _favoriteService) : Controller
    {
        private int GetCurrentUserId()
        {
            var userIdClaims = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(userIdClaims);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetCurrentUserId();
            var favorites = await _favoriteService.GetMyFavoritesAsync(userId);
            return View(favorites);
        }

        [HttpPost]
        public async Task<IActionResult> Toggle(int productId)
        {
            var userId = GetCurrentUserId();
            var isFavorited = await _favoriteService.ToggleFavoriteAsync(userId, productId);
            return Ok(new { isFavorited });
        }
    }
}
