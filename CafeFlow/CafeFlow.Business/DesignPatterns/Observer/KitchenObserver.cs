using CafeFlow.DataAccess.Repositories.Notifications;
using CafeFlow.Entity;
using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Observer
{
    public class KitchenObserver : IOrderObserver
    {
        private readonly INotificationRepository _notificationRepository;

        public KitchenObserver(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task Update(int orderId, OrderStatus orderStatus)
        {
            if(orderStatus == OrderStatus.Received || orderStatus == OrderStatus.Preparing  || orderStatus == OrderStatus.Cancelled)
            {
                var message = orderStatus switch
                {
                    OrderStatus.Received => $"Yeni sipariş mutfağa düştü. (Sipariş ${orderId})",
                    OrderStatus.Preparing => $"Sipariş hazırlanmaya başlandı. (Sipariş ${orderId})",
                    OrderStatus.Cancelled => $"DİKKAT: Sipariş #{orderId} iptal edildi, hazırlamayı durdurun!",
                    _ => $"Sipariş #{orderId} durumu güncellendi."
                };

                var notification = new Notification
                {
                    OrderId = orderId,
                    NotificationTarget = NotificationTarget.Kitchen,
                    Message = message,
                    IsRead = false
                };

                await _notificationRepository.CreateAsync(notification);
            }
        }
    }
}
