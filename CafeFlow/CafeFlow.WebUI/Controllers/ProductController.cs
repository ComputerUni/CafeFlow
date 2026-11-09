using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Detail(int id)
        {
            return View();
        }
    }
}
