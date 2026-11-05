using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult TrackOrder()
        {
            return View();
        }
    }
}
