using AutoMapper;
using CafeFlow.Business.Abstract;
using CafeFlow.Business.DesignPatterns.ChainOfResponsibility;
using CafeFlow.Business.DesignPatterns.FactoryMethod;
using CafeFlow.Business.DesignPatterns.Observer;
using CafeFlow.Business.DesignPatterns.State;
using CafeFlow.Business.DesignPatterns.Strategy;
using CafeFlow.DataAccess.Repositories.Orders;
using CafeFlow.DataAccess.Repositories.OrderStatusHistoryRepositories;
using CafeFlow.DTO.Order;
using CafeFlow.Entity;
using CafeFlow.Entity.Enums;

namespace CafeFlow.Business.Concrete
{
    public class OrderService(IOrderRepository _orderRepository, IMapper _mapper, IOrderFactory _orderFactory, IOrderShippingStrategy _orderShippingStrategy, OrderValidationHandler _orderValidatonHandler, OrderObserverObject _orderObserverObject, OrderStatusState _orderStatusState, IOrderStatusHistoryRepository _orderStatusHistoryRepository) : IOrderService
    {
        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var validationRequest = new OrderValidationRequest
            {
                ProductId = createOrderDto.OrderDetails.First().ProductId,
                Quantity = createOrderDto.OrderDetails.First().Quantity,
                OrderType = createOrderDto.OrderType,
                Address = createOrderDto.Address,
                TableId = createOrderDto.TableId,
                TotalAmount = createOrderDto.TotalAmount
            };

            await _orderValidatonHandler.Validate(validationRequest);

            var order = await _orderFactory.CreateOrder(createOrderDto);
            order.OrderCode = "CF" + "-" + DateTime.Now.Year + "-" + new Random().Next(10000000, 99999999);
            order.OrderStatus = OrderStatus.Received;

            await _orderRepository.CreateAsync(order);

            await _orderObserverObject.NotifyObserver(order.Id, OrderStatus.Received);

        }

        public async Task UpdateOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if(order is null)
            {
                throw new Exception("Aradığınız sipariş bulunamadı.");
            }

            var oldStatus = order.OrderStatus;

            var state = order.OrderStatus switch
            {
                OrderStatus.Received => (IOrderStatusState)new ReceivedState(),
                OrderStatus.Preparing => new PreparingState(),
                OrderStatus.Ready => new ReadyState(),
                OrderStatus.Delivered => new DeliveredState(),
                OrderStatus.Cancelled => new CancelledState()
            };

            var context = new OrderStatusState(state);

            await context.Handle(order);

            var history = new OrderStatusHistory
            {
                OrderId = order.Id,
                FromStatus = oldStatus,
                ToStatus = order.OrderStatus,
            };

            await _orderStatusHistoryRepository.CreateAsync(history);

            await _orderRepository.UpdateAsync(order);

            await _orderObserverObject.NotifyObserver(order.Id, order.OrderStatus);
        }
    }
}
