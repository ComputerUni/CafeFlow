using CafeFlow.DataAccess.Context;
using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Tables
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        public TableRepository(AppDbContext context) : base(context)
        {
        }
    }
}
