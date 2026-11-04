namespace CafeFlow.Business.DesignPatterns.Decorator
{
    public class CoffeeWithCream : CoffeeDecorator
    {
        private readonly decimal _additionalPrice;

        public CoffeeWithCream(ICoffee coffee, decimal additionalPrice) : base(coffee)
        {
            _additionalPrice = additionalPrice;
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Kremalı";
        }

        public override decimal GetPrice()
        {
            return _coffee.GetPrice() + _additionalPrice;
        }
    }
}
