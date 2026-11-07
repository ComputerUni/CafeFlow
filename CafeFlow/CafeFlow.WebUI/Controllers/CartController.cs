using CafeFlow.Business.Abstract;
using CafeFlow.DTO.Order;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CafeFlow.WebUI.Controllers
{
    public class CartController(IOrderService _orderService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            if (User.Identity.IsAuthenticated)
            {
                dto.AppUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            await _orderService.CreateOrderAsync(dto);
            TempData["OrderSuccess"] = true;
            return RedirectToAction("Confirmation");
        }

        [HttpGet]
        public async Task<IActionResult> Confirmation(string code)
        {
            if (string.IsNullOrEmpty(code)) return RedirectToAction("Index", "Default");
            var order = await _orderService.GetByCodeAsync(code);
            if (order == null) return NotFound();
            return View(order);
        }
    }
}
