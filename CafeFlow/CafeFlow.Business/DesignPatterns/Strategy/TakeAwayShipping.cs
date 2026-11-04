using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Strategy
{
    public class TakeAwayShipping : IOrderShippingStrategy
    {
        public decimal CalculateOrderShipping(decimal orderTotal)
        {
            return orderTotal + 0m;
        }
    }
}
