using CafeFlow.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController(INotificationService _notificationService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var notifications = await _notificationService.GetAllAsync();
            return View(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _notificationService.ChangeStatusAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
