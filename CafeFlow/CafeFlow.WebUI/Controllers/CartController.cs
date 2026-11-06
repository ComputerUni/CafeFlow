using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
