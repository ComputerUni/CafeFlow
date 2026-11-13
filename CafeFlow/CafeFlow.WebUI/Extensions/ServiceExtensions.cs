using CafeFlow.Business.Abstract;
using CafeFlow.Business.Concrete;
using CafeFlow.Business.DesignPatterns.ChainOfResponsibility;
using CafeFlow.Business.DesignPatterns.Observer;
using CafeFlow.Business.Settings;
using CafeFlow.DataAccess.Repositories.Categories;
using CafeFlow.DataAccess.Repositories.Comments;
using CafeFlow.DataAccess.Repositories.Customers;
using CafeFlow.DataAccess.Repositories.Dashboard;
using CafeFlow.DataAccess.Repositories.Favorites;
using CafeFlow.DataAccess.Repositories.Notifications;
using CafeFlow.DataAccess.Repositories.Orders;
using CafeFlow.DataAccess.Repositories.OrderStatusHistoryRepositories;
using CafeFlow.DataAccess.Repositories.Products;
using CafeFlow.DataAccess.Repositories.Tables;
using CafeFlow.DataAccess.UnitOfWork;

namespace CafeFlow.WebUI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TwilioSettings>(configuration.GetSection("TwilioSettings"));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderStatusHistoryRepository, OrderStatusHistoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITableRepository,  TableRepository>();
            services.AddScoped<ICommentRepository,  CommentRepository>();
            services.AddScoped<IDashboardRepository,  DashboardRepository>();
            services.AddScoped<IFavoriteRepository,  FavoriteRepository>();
        }

        public static void AddDesignPatterns(this IServiceCollection services)
        {
            services.AddScoped<IOrderObserver, KitchenObserver>();
            services.AddScoped<IOrderObserver, CashierObserver>();
            services.AddScoped<IOrderObserver, NotificationObserver>();
            services.AddScoped<IOrderObserver, SmsObserver>();

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
        }
    }
}
