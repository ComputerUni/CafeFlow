using CafeFlow.DTO.Order;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.FactoryMethod
{
    public interface IOrderFactory
    {
        Task<Order> CreateOrder(CreateOrderDto createOrderDto);
    }
}
