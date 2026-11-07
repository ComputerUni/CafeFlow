using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Strategy
{
    public class TableOrderShipping : IOrderShippingStrategy
    {
        public decimal CalculateOrderShipping(decimal orderTotal)
        {
            return 0m;
        }
    }
}
