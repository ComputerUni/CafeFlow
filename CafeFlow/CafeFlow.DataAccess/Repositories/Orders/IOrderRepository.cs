using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetByCodeWithDetailsAsync(string code);
        Task<List<Order>> GetMyOrders(int appUserId);
        Task<List<Order>> GetOrdersWithCustomerAsync();
        Task<Order> GetOrderDetailAsync(int id);
    }
}
