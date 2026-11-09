using CafeFlow.Business.Abstract;
using CafeFlow.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._ProductDetailLayoutViewComponents
{
    public class _ProductDetailLayoutScriptsViewComponent() : ViewComponent
    {
        public IViewComponentResult Invoke(ProductDetailPageViewModel model)
        {
            return View(model);
        }
    }
}
