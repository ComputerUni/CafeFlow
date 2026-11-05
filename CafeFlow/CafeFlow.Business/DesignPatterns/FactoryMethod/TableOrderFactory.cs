using CafeFlow.DTO.Order;
using CafeFlow.Entity;
using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.FactoryMethod
{
    public class TableOrderFactory : IOrderFactory
    {
        public async Task<Order> CreateOrder(CreateOrderDto createOrderDto)
        {

            var order = new Order();
            order.TableId = createOrderDto.TableId;
            order.OrderType = OrderType.Table;
            order.TotalAmount = createOrderDto.TotalAmount;
            order.Address = null;

            return order;
        }
    }
}
