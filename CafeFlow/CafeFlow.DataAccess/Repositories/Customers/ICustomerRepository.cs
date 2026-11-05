using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Customers
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer?> GetByAppUserIdAsync(int appUserId);
    }
}
