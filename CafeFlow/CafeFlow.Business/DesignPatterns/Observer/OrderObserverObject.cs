using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Observer
{
    public class OrderObserverObject
    {
        private readonly List<IOrderObserver> _orderObservers;

        public OrderObserverObject(IEnumerable<IOrderObserver> orderObservers)
        {
            _orderObservers = orderObservers.ToList();
        }

        public async Task AddObserver(IOrderObserver observer)
        {
            _orderObservers.Add(observer);
        }

        public async Task RemoveObserver(IOrderObserver observer)
        {
            _orderObservers.Remove(observer);
        }

        public async Task NotifyObserver(int orderId, OrderStatus orderStatus)
        {
            foreach (var observers in _orderObservers)
            {
                await observers.Update(orderId, orderStatus);
            }
        }
    }
}
