using CafeFlow.DTO.Order;

namespace CafeFlow.Business.Abstract
{
    public interface IOrderService
    {
        Task<string> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task UpdateOrderAsync(int id);
        Task<OrderConfirmationDto> GetByCodeAsync(string code);
    }
}
