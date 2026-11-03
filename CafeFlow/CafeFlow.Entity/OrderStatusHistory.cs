using CafeFlow.Entity.Common;
using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Entity
{
    public class OrderStatusHistory : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public OrderStatus FromStatus { get; set; }
        public OrderStatus ToStatus { get; set; }
    }
}
