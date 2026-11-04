using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Decorator
{
    public class ExtraShotCoffee : CoffeeDecorator
    {
        private readonly decimal _additionalPrice;

        public ExtraShotCoffee(ICoffee coffee, decimal additionalPrice) : base(coffee)
        {
            _additionalPrice = additionalPrice;
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Ekstra Shot";
        }

        public override decimal GetPrice()
        {
            return _coffee.GetPrice() + _additionalPrice;
        }
    }
}
