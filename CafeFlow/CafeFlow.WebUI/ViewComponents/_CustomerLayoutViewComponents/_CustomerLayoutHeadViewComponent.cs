using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._CustomerLayoutViewComponents
{
    public class _CustomerLayoutHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
