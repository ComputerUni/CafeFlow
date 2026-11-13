using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Dashboard
{
    public interface IDashboardRepository
    {
        Task<int> GetTotalOrderCountAsync();
        Task<decimal> GetTotalRevenueAsync();
        Task<decimal> GetTodayRevenueAsync();
        Task<int> GetActiveProductCountAsync();
        Task<int> GetUnreadNotificationCountAsync();
        Task<int> GetCustomerCountAsync();
        Task<Dictionary<string, int>> GetProductCountByCategoryAsync();
        Task<List<Order>> GetRecentOrderAsync();
        Task<List<Product>> GetLowStockProductsAsync(int threshold = 10);
    }
}
