using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Decorator
{
    public class CoffeeWithSyrup : CoffeeDecorator
    {
        private readonly string _syrupName;
        private readonly decimal _additionalPrice;

        public CoffeeWithSyrup(ICoffee coffee, string syrupName, decimal additionalPrice) : base(coffee)
        {
            _syrupName = syrupName;
            _additionalPrice = additionalPrice;
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + $", {_syrupName} Şurubu";
        }

        public override decimal GetPrice()
        {
            return _coffee.GetPrice() + _additionalPrice;
        }
    }
}
