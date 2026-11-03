using CafeFlow.Entity.Enums;

namespace CafeFlow.Business.DesignPatterns.ChainOfResponsibility
{
    public class OrderValidationRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public OrderType OrderType { get; set; }
        public string? Address { get; set; }
        public int? TableId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
