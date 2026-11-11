using CafeFlow.Business.Abstract;
using CafeFlow.DataAccess.Repositories.Orders;
using CafeFlow.Entity.Enums;


namespace CafeFlow.Business.DesignPatterns.Observer
{
    public class SmsObserver(ISmsService _smsService, IOrderRepository _orderRepository) : IOrderObserver
    {
        private const string ReceivedSid = "";
        private const string ReadySid = "";
        private const string DeliveredSid = "";

        public async Task Update(int orderId, OrderStatus orderStatus)
        {
            var order = await _orderRepository.GetOrderDetailAsync(orderId);
            if (order?.Customer?.Phone == null) return;

            switch (orderStatus)
            {
                case OrderStatus.Received:
                    await _smsService.SendSmsAsync(order.Customer.Phone, ReceivedSid,
                        new Dictionary<string, string> { { "1", orderId.ToString() } });
                    break;

                case OrderStatus.Ready:
                    await _smsService.SendSmsAsync(order.Customer.Phone, ReadySid,
                        new Dictionary<string, string> { { "1", orderId.ToString() } });
                    break;

                case OrderStatus.Delivered:
                    await _smsService.SendSmsAsync(order.Customer.Phone, DeliveredSid);
                    break;
            }
        }
    }
}
