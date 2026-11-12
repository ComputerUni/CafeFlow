using AutoMapper;
using CafeFlow.Business.Abstract;
using CafeFlow.Business.DesignPatterns.ChainOfResponsibility;
using CafeFlow.Business.DesignPatterns.Decorator;
using CafeFlow.Business.DesignPatterns.FactoryMethod;
using CafeFlow.Business.DesignPatterns.Observer;
using CafeFlow.Business.DesignPatterns.State;
using CafeFlow.Business.DesignPatterns.Strategy;
using CafeFlow.DataAccess.Repositories.Customers;
using CafeFlow.DataAccess.Repositories.Orders;
using CafeFlow.DataAccess.Repositories.OrderStatusHistoryRepositories;
using CafeFlow.DataAccess.Repositories.Products;
using CafeFlow.DTO.Order;
using CafeFlow.Entity;
using CafeFlow.Entity.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CafeFlow.Business.Concrete
{
    public class OrderService(IOrderRepository _orderRepository, IProductRepository _productRepository, IMapper _mapper, OrderObserverObject _orderObserverObject, IOrderStatusHistoryRepository _orderStatusHistoryRepository, ICustomerRepository _customerRepository) : IOrderService
    {
        public async Task<string> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var availabilityHandler = new ProductAvailabilityHandler(_productRepository);
            var minimumAmountHandler = new MinimumAmountHandler();
            var deliveryHandler = new DeliveryInfoHandler();

            availabilityHandler.SetNextHandler(minimumAmountHandler);
            minimumAmountHandler.SetNextHandler(deliveryHandler);

            foreach (var detail in createOrderDto.OrderDetails)
            {
                var validationRequest = new OrderValidationRequest
                {
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity,
                    OrderType = createOrderDto.OrderType,
                    Address = createOrderDto.Address,
                    TableId = createOrderDto.TableId,
                    TotalAmount = createOrderDto.TotalAmount
                };

                await availabilityHandler.Validate(validationRequest);
            }

            Customer customer;

            if (createOrderDto.AppUserId.HasValue)
            {
                customer = await _customerRepository.GetByAppUserIdAsync(createOrderDto.AppUserId.Value);
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
            order.CustomerId = customer.Id;
            order.OrderCode = "CF" + "-" + DateTime.Now.Year + "-" + new Random().Next(10000000, 99999999);
            order.OrderStatus = OrderStatus.Received;
            order.TotalAmount = createOrderDto.TotalAmount + shippingStrategy.CalculateOrderShipping(createOrderDto.TotalAmount);
            order.OrderNote = createOrderDto.OrderNote;
            order.EstimatedPickupTime = createOrderDto.EstimatedPickupTime;

            var orderDetailList = new List<OrderDetail>();

            foreach(var d in createOrderDto.OrderDetails)
            {
                var product = await _productRepository.GetByIdAsync(d.ProductId);
                var basePrice = product.Price;

                product.Stock -= d.Quantity;
                if (product.Stock < 0) product.Stock = 0;
                await _productRepository.UpdateAsync(product);

                ICoffee coffee = new BaseProduct(product.Name, basePrice);

                if(!string.IsNullOrWhiteSpace(d.SelectedOptions))
                {
                    if (d.SelectedOptions.Contains("Orta (Medium)"))
                        coffee = new CoffeeWithSize(coffee, "Orta (Medium)", 15);
                    else if (d.SelectedOptions.Contains("Büyük (Large)"))
                        coffee = new CoffeeWithSize(coffee, "Büyük (Large)", 25);

                    if (d.SelectedOptions.Contains("Yulaf Sütü"))
                        coffee = new CoffeeWithMilk(coffee, "Yulaf Sütü", 15);
                    else if (d.SelectedOptions.Contains("Badem Sütü"))
                        coffee = new CoffeeWithMilk(coffee, "Badem Sütü", 15);
                    else if (d.SelectedOptions.Contains("Laktozsuz"))
                        coffee = new CoffeeWithMilk(coffee, "Laktozsuz", 10);

                    if (d.SelectedOptions.Contains("+1 Shot Espresso"))
                        coffee = new ExtraShotCoffee(coffee, "+1 Shot Espresso", 20);

                    if (d.SelectedOptions.Contains("Vanilya"))
                        coffee = new CoffeeWithSyrup(coffee, "Vanilya", 15);
                    else if (d.SelectedOptions.Contains("Karamel"))
                        coffee = new CoffeeWithSyrup(coffee, "Karamel", 15);
                    else if (d.SelectedOptions.Contains("Fındık"))
                        coffee = new CoffeeWithSyrup(coffee, "Fındık", 15);
                }


                var additional = d.UnitPrice > basePrice ? (d.UnitPrice - basePrice) : d.AdditionalPrice;

                orderDetailList.Add(new OrderDetail
                {
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    UnitPrice = basePrice,
                    AdditionalPrice = additional,
                    SelectedOptions = d.SelectedOptions
                });
            }

            order.OrderDetails = orderDetailList;

            await _orderRepository.CreateAsync(order);

            await _orderObserverObject.NotifyObserver(order.Id, OrderStatus.Received);

            return order.OrderCode;

        }

        public async Task<List<OrderListDto>> GetAllAsync()
        {
            var order = await _orderRepository.GetOrdersWithCustomerAsync();
            return _mapper.Map<List<OrderListDto>>(order);
        }

        public async Task<OrderConfirmationDto> GetByCodeAsync(string code)
        {
            var order = await _orderRepository.GetByCodeWithDetailsAsync(code);
            if (order == null) return null;
            return _mapper.Map<OrderConfirmationDto>(order);
        }

        public async Task<List<OrderConfirmationDto>> GetMyOrders(int appUserId)
        {
            var myOrders = await _orderRepository.GetMyOrders(appUserId);
            return _mapper.Map<List<OrderConfirmationDto>>(myOrders);
        }

        public async Task<AdminOrderDetailDto> GetOrderDetailAsync(int id)
        {
            var order = await _orderRepository.GetOrderDetailAsync(id);
            if (order == null) return null;
            return _mapper.Map<AdminOrderDetailDto>(order);
        }

        public async Task UpdateOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order is null)
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
