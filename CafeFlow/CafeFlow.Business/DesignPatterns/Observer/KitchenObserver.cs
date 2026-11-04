using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Observer
{
    public class KitchenObserver : IOrderObserver
    {
        public async Task Update(int orderId, OrderStatus orderStatus)
        {
            if(orderStatus == OrderStatus.Received || orderStatus == OrderStatus.Cancelled)
            {
                Console.WriteLine($"Mutfak bildirimi: Sipariş #{orderId} - {orderStatus}");
            }
        }
    }
}
