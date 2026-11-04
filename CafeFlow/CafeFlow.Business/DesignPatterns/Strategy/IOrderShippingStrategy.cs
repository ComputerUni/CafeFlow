using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Strategy
{
    public interface IOrderShippingStrategy
    {
        decimal CalculateOrderShipping(decimal orderTotal);
    }
}
