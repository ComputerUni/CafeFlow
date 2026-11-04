using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.State
{
    public class CancelledState : IOrderStatusState
    {
        public Task Handle(Order order)
        {
            throw new Exception("Siparişiniz iptal edildiğinden geçiş yok.");
        }
    }
}
