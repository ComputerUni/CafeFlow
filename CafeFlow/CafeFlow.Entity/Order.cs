using CafeFlow.Entity.Common;
using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Entity
{
    public class Order : BaseEntity
    {
        public OrderType OrderType { get; set; }
        public string? Address { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string OrderCode { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int? TableId  { get; set; }
        public Table? Table  { get; set; }
        public decimal TotalAmount { get; set; }
        public string? OrderNote { get; set; }
        public string? EstimatedPickupTime { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<OrderStatusHistory> OrderStatusHistories { get; set; }
        public ICollection<Notification> Notifications { get; set; }

    }
}
