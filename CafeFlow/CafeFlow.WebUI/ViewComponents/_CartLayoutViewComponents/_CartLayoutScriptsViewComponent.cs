using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._CartLayoutViewComponents
{
    public class _CartLayoutScriptsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
