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
    }
}
