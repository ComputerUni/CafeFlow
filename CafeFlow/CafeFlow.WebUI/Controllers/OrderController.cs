using CafeFlow.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Controllers
{
    public class OrderController(IOrderService _orderService) : Controller
    {
        public async Task<IActionResult> TrackOrder(string orderCode)
        {
            if(string.IsNullOrWhiteSpace(orderCode))
            {
                return View();
            }

            ViewBag.code = orderCode;
            var order = await _orderService.GetByCodeAsync(orderCode);

            if(order is null)
            {
                ViewBag.NotFound = true;
                return View();
            }

            return View(order);
        }
    }
}
