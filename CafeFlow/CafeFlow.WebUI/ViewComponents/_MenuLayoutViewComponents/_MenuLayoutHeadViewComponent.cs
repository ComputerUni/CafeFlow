using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._MenuLayoutViewComponents
{
    public class _MenuLayoutHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
