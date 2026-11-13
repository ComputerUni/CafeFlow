using CafeFlow.Business.Abstract;
using CafeFlow.DataAccess.Repositories.Orders;
using CafeFlow.Entity.Enums;

namespace CafeFlow.Business.DesignPatterns.Observer
{
    public class SmsObserver(ISmsService _smsService, IOrderRepository _orderRepository) : IOrderObserver
    {
        private const string SandboxTemplateSid = "";

        public async Task Update(int orderId, OrderStatus orderStatus)
        {
            var order = await _orderRepository.GetOrderDetailAsync(orderId);
            if (order?.Customer?.Phone == null) return;

            var time = DateTime.Now.ToString("HH:mm");

            switch (orderStatus)
            {
                case OrderStatus.Received:
                    await _smsService.SendSmsAsync(order.Customer.Phone, SandboxTemplateSid,
                        new Dictionary<string, string> { { "1", $"CafeFlow #{orderId} Siparişiniz Alındı" }, { "2", time } });
                    break;

                case OrderStatus.Ready:
                    await _smsService.SendSmsAsync(order.Customer.Phone, SandboxTemplateSid,
                        new Dictionary<string, string> { { "1", $"CafeFlow #{orderId} Siparişiniz Hazır" }, { "2", time } });
                    break;

                case OrderStatus.Delivered:
                    await _smsService.SendSmsAsync(order.Customer.Phone, SandboxTemplateSid,
                        new Dictionary<string, string> { { "1", $"CafeFlow #{orderId} Siparişiniz Teslim Edildi" }, { "2", time } });
                    break;
            }
        }
    }
}