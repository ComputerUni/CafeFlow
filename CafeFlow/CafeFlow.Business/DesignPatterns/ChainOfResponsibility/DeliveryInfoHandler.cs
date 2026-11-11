using CafeFlow.Entity.Enums;

namespace CafeFlow.Business.DesignPatterns.ChainOfResponsibility
{
    public class DeliveryInfoHandler : OrderValidationHandler
    {
        public override async Task Validate(OrderValidationRequest request)
        {
            if(request.OrderType == OrderType.Online)
            {
                if(string.IsNullOrEmpty(request.Address))
                {
                    throw new Exception("Online sipariş için adres gereklidir.");
                }
            }
            else if(request.OrderType == OrderType.Table)
            {
                if(request.TableId == null)
                {
                    throw new Exception("Masa siparişi için masa seçimi gereklidir.");
                }
            }

            if (NextHandler != null)
            {
                await NextHandler.Validate(request);
            }

        }
    }
}
