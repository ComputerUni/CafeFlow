using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using CafeFlow.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.DesignPatterns.ChainOfResponsibility
{
    public class DeliveryInfoHandler : OrderValidationHandler
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public DeliveryInfoHandler(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

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

        }
    }
}
