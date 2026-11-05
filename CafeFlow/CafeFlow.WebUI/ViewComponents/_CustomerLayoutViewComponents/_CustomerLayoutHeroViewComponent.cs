using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._CustomerLayoutViewComponents
{
    public class _CustomerLayoutHeroViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
