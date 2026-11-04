using CafeFlow.DTO.Order;
using CafeFlow.Entity;
using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.FactoryMethod
{
    public class TakeAwayOrderFactory : IOrderFactory
    {
        public async Task<Order> CreateOrder(CreateOrderDto createOrderDto)
        {
            var order = new Order();
            order.TableId = null;
            order.CustomerId = createOrderDto.CustomerId;
            order.OrderCode = createOrderDto.OrderCode;
            order.OrderStatus = createOrderDto.OrderStatus;
            order.OrderType = OrderType.TakeAway;
            order.TotalAmount = createOrderDto.TotalAmount;
            order.Address = null;

            return order;
        }
    }
}
