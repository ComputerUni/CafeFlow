using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
