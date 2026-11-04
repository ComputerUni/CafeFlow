using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.State
{
    public class OrderStatusState
    {
        private IOrderStatusState _orderStatusState;

        public OrderStatusState(IOrderStatusState orderStatusState)
        {
            _orderStatusState = orderStatusState;
        }

        public void SetState(IOrderStatusState state)
        {
            _orderStatusState = state;
        }

        public async Task Handle(Order order)
        {
            await _orderStatusState.Handle(order);
        }
    }
}
