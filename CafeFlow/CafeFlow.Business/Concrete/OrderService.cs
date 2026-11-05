using AutoMapper;
using CafeFlow.Business.Abstract;
using CafeFlow.Business.DesignPatterns.ChainOfResponsibility;
using CafeFlow.Business.DesignPatterns.FactoryMethod;
using CafeFlow.Business.DesignPatterns.Observer;
using CafeFlow.Business.DesignPatterns.State;
using CafeFlow.Business.DesignPatterns.Strategy;
using CafeFlow.DataAccess.Repositories.Customers;
using CafeFlow.DataAccess.Repositories.Orders;
using CafeFlow.DataAccess.Repositories.OrderStatusHistoryRepositories;
using CafeFlow.DTO.Order;
using CafeFlow.Entity;
using CafeFlow.Entity.Enums;

namespace CafeFlow.Business.Concrete
{
    public class OrderService(IOrderRepository _orderRepository, IMapper _mapper, OrderValidationHandler _orderValidatonHandler, OrderObserverObject _orderObserverObject, IOrderStatusHistoryRepository _orderStatusHistoryRepository, ICustomerRepository _customerRepository) : IOrderService
    {
        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            Customer customer;

            if(createOrderDto.AppUserId.HasValue)
            {
                customer = await _customerRepository.GetByAppUserIdAsync(createOrderDto.AppUserId.Value);

                if(customer is null)
                {
                    customer = new Customer
                    {
                        AppUserId = createOrderDto.AppUserId.Value,
                        FullName = createOrderDto.CustomerName,
                        Email = createOrderDto.Email,
                        Phone = createOrderDto.PhoneNumber,
                        Address = createOrderDto.Address
                    };
                    await _customerRepository.CreateAsync(customer);
                }
            }
            else
            {
                customer = new Customer
                {
                    FullName = createOrderDto.CustomerName,
                    Email = createOrderDto.Email,
                    Phone = createOrderDto.PhoneNumber,
                    Address = createOrderDto.Address
                };
                await _customerRepository.CreateAsync(customer);
            }

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

            IOrderFactory orderFactory = createOrderDto.OrderType switch
            {
                OrderType.Online => new OnlineOrderFactory(),
                OrderType.TakeAway => new TakeAwayOrderFactory(),
                OrderType.Table => new TableOrderFactory(),
            };


            IOrderShippingStrategy shippingStrategy = createOrderDto.OrderType switch
            {
                OrderType.Online => new OnlineShipping(),
                OrderType.TakeAway => new TakeAwayShipping(),
                OrderType.Table => new TableOrderShipping(),
            };

            var order = await orderFactory.CreateOrder(createOrderDto);
            order.OrderCode = "CF" + "-" + DateTime.Now.Year + "-" + new Random().Next(10000000, 99999999);
            order.OrderStatus = OrderStatus.Received;
            order.TotalAmount = createOrderDto.TotalAmount + shippingStrategy.CalculateOrderShipping(createOrderDto.TotalAmount);

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
