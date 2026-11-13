using CafeFlow.DataAccess.Context;
using CafeFlow.Entity;
using Microsoft.EntityFrameworkCore;


namespace CafeFlow.DataAccess.Repositories.Dashboard
{
    public class DashboardRepository(AppDbContext _context) : IDashboardRepository
    {
        public async Task<int> GetActiveProductCountAsync()
        {
            return await _context.Products.CountAsync(x => x.IsActive);
        }

        public async Task<int> GetCustomerCountAsync()
        {
            return await _context.Customers.CountAsync();
        }

        public async Task<List<Product>> GetLowStockProductsAsync(int threshold = 10)
        {
            return await _context.Products.Include(x => x.Category).Where(x => x.Stock <= threshold).OrderBy(x => x.Stock).Take(5).ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetProductCountByCategoryAsync()
        {
            return await _context.Products.Include(x => x.Category).GroupBy(x => x.Category.Name).ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<List<Order>> GetRecentOrderAsync()
        {
            return await _context.Orders.OrderByDescending(x => x.Id).Take(6).ToListAsync();
        }

        public async Task<decimal> GetTodayRevenueAsync()
        {
            return await _context.Orders.Where(x => x.CreatedAt.Date == DateTime.Today).SumAsync(x => x.TotalAmount);
        }

        public async Task<int> GetTotalOrderCountAsync()
        {
            return await _context.Orders.CountAsync();
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _context.Orders.SumAsync(x => x.TotalAmount);
        }

        public async Task<int> GetUnreadNotificationCountAsync()
        {
            return await _context.Notifications.CountAsync(x => !x.IsRead);
        }
    }
}
