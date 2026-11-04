using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Observer
{
    public class NotificationObserver : IOrderObserver
    {
        private readonly IGenericRepository<Notification> _notificationRepository;

        public NotificationObserver(IGenericRepository<Notification> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task Update(int orderId, OrderStatus orderStatus)
        {
            var message = orderStatus switch
            {
                OrderStatus.Received => "Siparişiniz alındı.",
                OrderStatus.Preparing => "Siparişiniz hazırlanıyor.",
                OrderStatus.Ready => "Siparişiniz hazır.",
                OrderStatus.Delivered => "Siparişiniz teslim edildi.",
                OrderStatus.Cancelled => "Siparişiniz iptal edildi.",
                _ => "Sipariş durumunuz güncellendi"
            };

            var notification = new Notification
            {
                OrderId = orderId,
                NotificationTarget = NotificationTarget.Customer,
                Message = message,
                IsRead = false
            };

            await _notificationRepository.CreateAsync(notification);
        }
    }
}
