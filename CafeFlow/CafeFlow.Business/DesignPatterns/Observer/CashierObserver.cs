using CafeFlow.DataAccess.Repositories.Notifications;
using CafeFlow.Entity;
using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Observer
{
    public class CashierObserver : IOrderObserver
    {
        private readonly INotificationRepository _notificationRepository;

        public CashierObserver(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task Update(int orderId, OrderStatus orderStatus)
        {
            var message = orderStatus switch
            {
                OrderStatus.Received => $"Kasa: #{orderId} nolu yeni sipariş kaydı açıldı",
                OrderStatus.Ready => $"Kasa: #{orderId} nolu sipariş hazır, teslimata hazır.",
                OrderStatus.Delivered => $"Kasa: #{orderId} nolu sipariş teslim edildi, hesap kapatılabilir",
                OrderStatus.Cancelled => $"Kasa: #{orderId} nolu sipariş iptal edildi (İade/İptal işlemi).",
                _ => $"Kasa: #{orderId} durumu değişti: {orderStatus}"
            };

            var notification = new Notification
            {
                OrderId = orderId,
                NotificationTarget = NotificationTarget.Cashier,
                Message = message,
                IsRead = false
            };

            await _notificationRepository.CreateAsync(notification);
        }
    }
}
