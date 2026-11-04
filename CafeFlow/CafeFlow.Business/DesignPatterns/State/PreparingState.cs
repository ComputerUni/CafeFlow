using CafeFlow.Entity;
using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.State
{
    public class PreparingState : IOrderStatusState
    {
        public async Task Handle(Order order)
        {
            order.OrderStatus = OrderStatus.Ready;
        }
    }
}
