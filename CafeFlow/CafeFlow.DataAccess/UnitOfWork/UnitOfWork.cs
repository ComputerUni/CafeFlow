using CafeFlow.DataAccess.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.UnitOfWork
{
    public class UnitOfWork(AppDbContext _context) : IUnitOfWork
    {
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
