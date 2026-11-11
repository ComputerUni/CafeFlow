using CafeFlow.DTO.Order;
using CafeFlow.Entity;

namespace CafeFlow.Business.Abstract
{
    public interface IOrderService
    {
        Task<string> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task UpdateOrderAsync(int id);
        Task<OrderConfirmationDto> GetByCodeAsync(string code);
        Task<List<OrderConfirmationDto>> GetMyOrders(int appUserId);
        Task<List<OrderListDto>> GetAllAsync();
        Task<AdminOrderDetailDto> GetOrderDetailAsync(int id);
    }
}
