using CafeFlow.DTO.OrderDetail;
using CafeFlow.Entity.Enums;

namespace CafeFlow.DTO.Order
{
    public class CreateOrderDto
    {
        public OrderType OrderType { get; set; }
        public string? Address { get; set; }
        public int? TableId { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? AppUserId { get; set; }
        public List<CreateOrderDetailDto> OrderDetails { get; set; }
    }
}
