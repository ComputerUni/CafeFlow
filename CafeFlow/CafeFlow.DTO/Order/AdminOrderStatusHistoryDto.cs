using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.Order
{
    public class AdminOrderStatusHistoryDto
    {
        public OrderStatus FromStatus { get; set; }
        public OrderStatus ToStatus { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
