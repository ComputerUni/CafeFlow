using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.OrderStatusHistory
{
    public class OrderStatusHistoryListDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderStatus FromStatus { get; set; }
        public OrderStatus ToStatus { get; set; }
    }
}
