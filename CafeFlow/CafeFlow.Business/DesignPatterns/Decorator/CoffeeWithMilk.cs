using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Decorator
{
    public class CoffeeWithMilk : CoffeeDecorator
    {
        private readonly string _milkType;
        private readonly decimal _additionalPrice;

        public CoffeeWithMilk(ICoffee coffee, string milkType, decimal additionalPrice) : base(coffee)
        {
            _milkType = milkType;
            _additionalPrice = additionalPrice;
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + $", {_milkType}";
        }

        public override decimal GetPrice()
        {
            return _coffee.GetPrice() + _additionalPrice;
        }
    }
}
