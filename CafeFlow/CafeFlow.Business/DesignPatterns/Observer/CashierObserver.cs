using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Observer
{
    public class CashierObserver : IOrderObserver
    {
        public async Task Update(int orderId, OrderStatus orderStatus)
        {
            Console.WriteLine($"Kasa bildirimi: Sipariş #{orderId} - {orderStatus}");
        }
    }
}
