using CafeFlow.Business.Abstract;
using CafeFlow.DTO.Order;
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


        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var order = await _orderService.GetOrderDetailAsync(id);
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Detail(UpdateOrderDto dto)
        {
            try
            {
                await _orderService.UpdateOrderAsync(dto.Id);
                TempData["SuccessMessage"] = "Sipariş durumu başarıyla güncellendi ve bildirimler iletildi.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("Detail", new { id = dto.Id });
        }

    }
}
