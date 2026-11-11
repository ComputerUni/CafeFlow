using CafeFlow.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController(IOrderService _orderService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllAsync();
            return View(orders);
        }
    }
}
