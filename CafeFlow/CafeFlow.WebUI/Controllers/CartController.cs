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
        public async Task<IActionResult> Index([FromBody] CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Any())
                    .ToDictionary(
                        k => k.Key,
                        v => v.Value.Errors.Select(e => e.ErrorMessage).ToList()
                    );
                return BadRequest(new { success = false, message = "Geçersiz veri.", errors });
            }

            if (User.Identity.IsAuthenticated)
            {
                dto.AppUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            try
            {
                var orderCode = await _orderService.CreateOrderAsync(dto);
                return Ok(new { success = true, orderCode });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }

        }

        [HttpGet]
        [Route("Cart/Confirmation/{code}")]
        public async Task<IActionResult> Confirmation(string code)
        {
            if (string.IsNullOrEmpty(code)) return RedirectToAction("Index", "Default");
            var order = await _orderService.GetByCodeAsync(code);
            if (order == null) return NotFound();
            return View(order);
        }
    }
}
