using CafeFlow.DTO.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Abstract
{
    public interface INotificationService
    {
        Task<List<NotificationListDto>> GetAllAsync();
        Task ChangeStatusAsync(int id);
    }
}
