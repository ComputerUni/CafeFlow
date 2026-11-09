using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._ProductDetailLayoutViewComponents
{
    public class _ProductDetailLayoutHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
