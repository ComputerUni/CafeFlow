using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Observer
{
    public interface IOrderObserver
    {
        Task Update(int orderId, OrderStatus orderStatus);
    }
}
