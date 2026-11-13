using AutoMapper;
using CafeFlow.Business.Abstract;
using CafeFlow.DataAccess.Repositories.Dashboard;
using CafeFlow.DTO.Order;
using CafeFlow.DTO.Product;

namespace CafeFlow.Business.Concrete
{
    public class DashboardService(IDashboardRepository _dashboardRepository, IMapper _mapper) : IDashboardService
    {
        public async Task<int> GetActiveProductCountAsync()
        {
            return await _dashboardRepository.GetActiveProductCountAsync();
        }

        public async Task<int> GetCustomerCountAsync()
        {
            return await _dashboardRepository.GetCustomerCountAsync();
        }

        public async Task<List<ProductListDto>> GetLowStockProductsAsync(int threshold = 10)
        {
            var products = await _dashboardRepository.GetLowStockProductsAsync(threshold);
            return _mapper.Map<List<ProductListDto>>(products);
        }

        public async Task<Dictionary<string, int>> GetProductCountByCategoryAsync()
        {
            return await _dashboardRepository.GetProductCountByCategoryAsync();
        }

        public async Task<List<OrderListDto>> GetRecentOrderAsync()
        {
            var orders =  await _dashboardRepository.GetRecentOrderAsync();
            return _mapper.Map<List<OrderListDto>>(orders);
        }

        public async Task<decimal> GetTodayRevenueAsync()
        {
            return await _dashboardRepository.GetTodayRevenueAsync();
        }

        public async Task<int> GetTotalOrderCountAsync()
        {
            return await _dashboardRepository.GetTotalOrderCountAsync();
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await _dashboardRepository.GetTotalRevenueAsync();
        }

        public async Task<int> GetUnreadNotificationCountAsync()
        {
            return await _dashboardRepository.GetUnreadNotificationCountAsync();
        }
    }
}
