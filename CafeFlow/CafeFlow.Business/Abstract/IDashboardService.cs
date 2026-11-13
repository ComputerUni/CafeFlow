using CafeFlow.DTO.Order;
using CafeFlow.DTO.Product;
using CafeFlow.Entity;

namespace CafeFlow.Business.Abstract
{
    public interface IDashboardService
    {
        Task<int> GetTotalOrderCountAsync();
        Task<decimal> GetTotalRevenueAsync();
        Task<decimal> GetTodayRevenueAsync();
        Task<int> GetActiveProductCountAsync();
        Task<int> GetUnreadNotificationCountAsync();
        Task<int> GetCustomerCountAsync();
        Task<Dictionary<string, int>> GetProductCountByCategoryAsync();
        Task<List<OrderListDto>> GetRecentOrderAsync();
        Task<List<ProductListDto>> GetLowStockProductsAsync(int threshold = 10);
    }
}
