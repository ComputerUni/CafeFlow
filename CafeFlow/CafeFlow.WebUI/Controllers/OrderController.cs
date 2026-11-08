using CafeFlow.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        public async Task<IActionResult> MyOrders()
        {
            var appUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var orders = await _orderService.GetMyOrders(appUserId);
            return View(orders);
        }
    }
}
