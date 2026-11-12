using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DTO.Notification
{
    public class NotificationListDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public NotificationTarget NotificationTarget { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
