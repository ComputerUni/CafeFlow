using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.Order
{
    public class AdminOrderDetailDto
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderType OrderType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public string? OrderNote { get; set; }
        public string? EstimatedPickupTime { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int? TableId { get; set; }
        public int? TableNumber { get; set; }
        public List<AdminOrderItemDto> OrderItems { get; set; }
        public List<AdminOrderStatusHistoryDto> StatusHistories { get; set; }
    }
}
