using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.Decorator
{
    public class BaseProduct : ICoffee
    {
        private readonly string _name;
        private readonly decimal _price;

        public BaseProduct(string name, decimal price)
        {
            _name = name;
            _price = price;
        }

        public string GetDescription()
        {
            return _name;
        }

        public decimal GetPrice()
        {
            return _price;
        }
    }
}
