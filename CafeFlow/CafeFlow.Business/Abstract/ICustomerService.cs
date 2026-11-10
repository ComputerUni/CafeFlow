using CafeFlow.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Abstract
{
    public interface ICustomerService
    {
        Task<CustomerListDto?> GetByAppUserIdAsync(int appUserId);
    }
}
