using CafeFlow.Entity.Enums;

namespace CafeFlow.Business.DesignPatterns.ChainOfResponsibility
{
    public class MinimumAmountHandler : OrderValidationHandler
    {
        public override async Task Validate(OrderValidationRequest request)
        {
            if (request.OrderType == OrderType.Online && request.TotalAmount < 100)
            {
                throw new Exception("Online siparişlerde minimum sipariş tutarınız en az 100 TL olmalıdır.");
            }

            if (NextHandler != null)
            {
                await NextHandler.Validate(request);
            }
        }
    }
}
