using CafeFlow.DataAccess.Context;
using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Order> GetByCodeWithDetailsAsync(string code)
        {
            return await _context.Orders.Include(o => o.Customer).Include(o => o.OrderDetails).ThenInclude(d => d.Product).FirstOrDefaultAsync(o => o.OrderCode == code);
        }

        public async Task<List<Order>> GetMyOrders(int appUserId)
        {
            return await _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Product).Include(o => o.Customer).Where(o => o.Customer.AppUserId == appUserId).OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<Order> GetOrderDetailAsync(int id)
        {
            return await _context.Orders.Include(x => x.Customer).Include(x => x.OrderDetails).ThenInclude(x => x.Product).Include(x => x.OrderStatusHistories).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Order>> GetOrdersWithCustomerAsync()
        {
            return await _context.Orders.Include(x => x.Customer).OrderBy(x => x.CreatedAt).ToListAsync();
        }
    }
}
