using AutoMapper;
using CafeFlow.Business.Abstract;
using CafeFlow.DataAccess.Repositories.Notifications;
using CafeFlow.DTO.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Concrete
{
    public class NotificationService(INotificationRepository _notificationRepository, IMapper _mapper) : INotificationService
    {
        public async Task ChangeStatusAsync(int id)
        {
            var notification = await _notificationRepository.GetByIdAsync(id);
            notification.IsRead = !notification.IsRead;
            await _notificationRepository.UpdateAsync(notification);
        }

        public async Task<List<NotificationListDto>> GetAllAsync()
        {
            var notifications = await _notificationRepository.GetAllAsync();
            return _mapper.Map<List<NotificationListDto>>(notifications);
        }
    }
}
