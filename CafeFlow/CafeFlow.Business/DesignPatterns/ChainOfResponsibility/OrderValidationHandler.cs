namespace CafeFlow.Business.DesignPatterns.ChainOfResponsibility
{
    public abstract class OrderValidationHandler
    {
        protected OrderValidationHandler NextHandler;

        public void SetNextHandler(OrderValidationHandler handler)
        {
            this.NextHandler = handler;
        }

        public abstract Task Validate(OrderValidationRequest request);
    }
}
