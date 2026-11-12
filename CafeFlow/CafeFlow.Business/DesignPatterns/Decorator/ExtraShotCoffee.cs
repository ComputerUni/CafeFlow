using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Decorator
{
    public class ExtraShotCoffee : CoffeeDecorator
    {
        private readonly decimal _additionalPrice;
        private readonly string _description;

        public ExtraShotCoffee(ICoffee coffee, string description, decimal additionalPrice) : base(coffee)
        {
            _additionalPrice = additionalPrice;
            _description = description;
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + $", {_description}";
        }

        public override decimal GetPrice()
        {
            return _coffee.GetPrice() + _additionalPrice;
        }
    }
}
