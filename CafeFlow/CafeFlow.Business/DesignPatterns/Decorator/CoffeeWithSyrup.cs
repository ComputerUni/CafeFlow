using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Decorator
{
    public class CoffeeWithSyrup : CoffeeDecorator
    {
        private readonly decimal _additionalPrice;

        public CoffeeWithSyrup(ICoffee coffee, decimal additionalPrice) : base(coffee)
        {
            _additionalPrice = additionalPrice;
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Şurup Özlü";
        }

        public override decimal GetPrice()
        {
            return _coffee.GetPrice() + _additionalPrice;
        }
    }
}
