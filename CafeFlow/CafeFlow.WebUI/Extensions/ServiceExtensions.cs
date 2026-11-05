using CafeFlow.Business.Abstract;
using CafeFlow.Business.Concrete;
using CafeFlow.Business.DesignPatterns.ChainOfResponsibility;
using CafeFlow.Business.DesignPatterns.FactoryMethod;
using CafeFlow.Business.DesignPatterns.Observer;
using CafeFlow.Business.DesignPatterns.State;
using CafeFlow.Business.DesignPatterns.Strategy;
using CafeFlow.DataAccess.Repositories.Categories;
using CafeFlow.DataAccess.Repositories.Notifications;
using CafeFlow.DataAccess.Repositories.Orders;
using CafeFlow.DataAccess.Repositories.OrderStatusHistoryRepositories;
using CafeFlow.DataAccess.Repositories.Products;

namespace CafeFlow.WebUI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderStatusHistoryRepository, OrderStatusHistoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
        }

        public static void AddDesignPatterns(this IServiceCollection services)
        {
            services.AddScoped<IOrderObserver, KitchenObserver>();
            services.AddScoped<IOrderObserver, CashierObserver>();
            services.AddScoped<IOrderObserver, NotificationObserver>();

            services.AddScoped<OrderObserverObject>();

            services.AddScoped<ProductAvailabilityHandler>();
            services.AddScoped<DeliveryInfoHandler>();
            services.AddScoped<MinimumAmountHandler>();

            services.AddScoped<OrderValidationHandler>(sp =>
            {
                var availability = sp.GetRequiredService<ProductAvailabilityHandler>();
                var delivery = sp.GetRequiredService<DeliveryInfoHandler>();
                var minimum = sp.GetRequiredService<MinimumAmountHandler>();

                availability.SetNextHandler(delivery);
                delivery.SetNextHandler(minimum);

                return availability;
            });

            services.AddScoped<IOrderFactory, OnlineOrderFactory>();
            services.AddScoped<IOrderShippingStrategy, OnlineShipping>();
        }
    }
}
