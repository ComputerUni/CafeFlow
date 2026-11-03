using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.Order
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public OrderType OrderType { get; set; }
        public string? Address { get; set; }
        public int CustomerId { get; set; }
        public string OrderCode { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int? TableId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
