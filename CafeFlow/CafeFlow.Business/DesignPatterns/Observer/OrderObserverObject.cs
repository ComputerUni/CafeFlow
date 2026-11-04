using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Observer
{
    public class OrderObserverObject
    {
        private readonly Collection<IOrderObserver> _orderObservers;

        public OrderObserverObject(Collection<IOrderObserver> orderObservers)
        {
            _orderObservers = orderObservers;
        }

        public void AddObserver(IOrderObserver observer)
        {
            _orderObservers.Add(observer);
        }

        public void RemoveObserver(IOrderObserver observer)
        {
            _orderObservers.Remove(observer);
        }

        public void NotifyObserver(int orderId, OrderStatus orderStatus)
        {
            foreach(var observers in _orderObservers)
            {
                observers.Update(orderId, orderStatus);
            }
        }
    }
}
