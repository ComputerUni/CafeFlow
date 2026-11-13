using CafeFlow.Business.Abstract;
using CafeFlow.DTO.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController(IDashboardService _dashboardService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var dto = new AdminDashboardDto
            {
                TotalRevenue = await _dashboardService.GetTotalRevenueAsync(),
                TodayRevenue = await _dashboardService.GetTodayRevenueAsync(),
                TotalOrderCount = await _dashboardService.GetTotalOrderCountAsync(),
                ActiveProductCount = await _dashboardService.GetActiveProductCountAsync(),
                CustomerCount = await _dashboardService.GetCustomerCountAsync(),
                UnreadNotificationCount = await _dashboardService.GetUnreadNotificationCountAsync(),
                ProductCountByCategory = await _dashboardService.GetProductCountByCategoryAsync(),
                LowStockProducts = await _dashboardService.GetLowStockProductsAsync(),
                RecentOrders = await _dashboardService.GetRecentOrderAsync()
            };

            return View(dto);
        }
    }
}
