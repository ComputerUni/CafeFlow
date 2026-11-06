using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._MenuLayoutViewComponents
{
    public class _MenuLayoutPageHeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
