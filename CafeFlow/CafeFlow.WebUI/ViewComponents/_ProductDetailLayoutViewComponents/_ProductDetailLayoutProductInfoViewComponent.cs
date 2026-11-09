using CafeFlow.DTO.ProductDetail;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._ProductDetailLayoutViewComponents
{
    public class _ProductDetailLayoutProductInfoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(ResultProductDetailDto product)
        {
            return View(product);
        }
    }
}
