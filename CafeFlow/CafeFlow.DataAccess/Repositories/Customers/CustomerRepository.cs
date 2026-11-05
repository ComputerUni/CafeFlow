using CafeFlow.DataAccess.Context;
using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using Microsoft.EntityFrameworkCore;

namespace CafeFlow.DataAccess.Repositories.Customers
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Customer?> GetByAppUserIdAsync(int appUserId)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.AppUserId == appUserId);
        }
    }
}
