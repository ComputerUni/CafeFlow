using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.Order
{
    public class OrderConfirmationDto
    {
        public string OrderCode { get; set; }
        public OrderType OrderType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int? TableId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderDetailConfirmDto> OrderDetails { get; set; }
    }
}
