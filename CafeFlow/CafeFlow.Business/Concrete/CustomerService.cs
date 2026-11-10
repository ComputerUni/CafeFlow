using AutoMapper;
using CafeFlow.Business.Abstract;
using CafeFlow.DataAccess.Repositories.Customers;
using CafeFlow.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Concrete
{
    public class CustomerService(ICustomerRepository _customerRepository, IMapper _mapper) : ICustomerService
    {
        public async Task<CustomerListDto?> GetByAppUserIdAsync(int appUserId)
        {
            var customer = await _customerRepository.GetByAppUserIdAsync(appUserId);
            if (customer is null) return null;
            return _mapper.Map<CustomerListDto>(customer);
        }
    }
}
