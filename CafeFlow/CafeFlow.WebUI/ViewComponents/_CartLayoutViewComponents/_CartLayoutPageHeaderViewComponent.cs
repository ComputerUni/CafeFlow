using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._CartLayoutViewComponents
{
    public class _CartLayoutPageHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
