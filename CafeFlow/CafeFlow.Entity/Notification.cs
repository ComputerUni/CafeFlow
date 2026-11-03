using CafeFlow.Entity.Common;
using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Entity
{
    public class Notification : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public NotificationTarget NotificationTarget { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
