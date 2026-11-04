using CafeFlow.DataAccess.Context;
using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Notifications
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
