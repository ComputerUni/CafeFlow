using CafeFlow.DataAccess.Repositories.GenericRepositories;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.DataAccess.Repositories.Favorites
{
    public interface IFavoriteRepository : IGenericRepository<Favorite>
    {
        Task<Favorite?> GetByCustomerAndProductAsync(int customerId, int productId);
        Task<List<int>> GetFavoriteProductIdsByCustomerAsync(int customerId);
        Task<List<Favorite>> GetFavoritesWithProductByCustomerAsync(int customerId);
        Task HardDeleteAsync(Favorite favorite);
    }
}
