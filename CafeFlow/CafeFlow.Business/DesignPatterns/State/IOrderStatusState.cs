using CafeFlow.DTO.Order;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.State
{
    public interface IOrderStatusState
    {
        Task Handle(Order order);
    }
}
