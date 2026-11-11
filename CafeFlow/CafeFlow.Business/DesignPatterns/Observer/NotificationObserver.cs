using CafeFlow.DataAccess.Repositories.Notifications;
using CafeFlow.Entity;
using CafeFlow.Entity.Enums;

namespace CafeFlow.Business.DesignPatterns.Observer
{
    public class NotificationObserver : IOrderObserver
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationObserver(INotificationRepository notificationRepository)
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
