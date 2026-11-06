using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Decorator
{
    public class CoffeeWithSize : CoffeeDecorator
    {
        private readonly string _sizeName;
        private readonly decimal _additionalPrice;

        public CoffeeWithSize(ICoffee coffee, string sizeName, decimal additionalPrice) : base(coffee)
        {
            _sizeName = sizeName;
            _additionalPrice = additionalPrice;
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + $", {_sizeName} Boy";
        }

        public override decimal GetPrice()
        {
            return _coffee.GetPrice() + _additionalPrice;
        }
    }
}
