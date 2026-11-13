using CafeFlow.DataAccess.Context;
using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Favorites
{
    public class FavoriteRepository : GenericRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Favorite?> GetByCustomerAndProductAsync(int customerId, int productId)
        {
            return await _context.Favorites.FirstOrDefaultAsync(x => x.CustomerId == customerId && x.ProductId == productId);
        }

        public async Task<List<int>> GetFavoriteProductIdsByCustomerAsync(int customerId)
        {
            return await _context.Favorites.Where(x => x.CustomerId == customerId).Select(x => x.ProductId).ToListAsync();
        }

        public async Task<List<Favorite>> GetFavoritesWithProductByCustomerAsync(int customerId)
        {
            return await _context.Favorites.Include(x => x.Product).ThenInclude(p => p.Category).Where(x => x.CustomerId == customerId).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task HardDeleteAsync(Favorite favorite)
        {
            await _context.Favorites.Where(x => x.Id == favorite.Id).ExecuteDeleteAsync();
        }
    }
}
