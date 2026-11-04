using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.State
{
    public class DeliveredState : IOrderStatusState
    {
        public Task Handle(Order order)
        {
            throw new Exception("Siparişiniz teslim edildiğinden geçiş yok.");
        }
    }
}
