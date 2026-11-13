using CafeFlow.DTO.Favorite;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Abstract
{
    public interface IFavoriteService
    {
        Task<bool> ToggleFavoriteAsync(int customerId, int productId);
        Task<HashSet<int>> GetUserFavoriteProductIdsAsync(int customerId);
        Task<List<FavoriteProductDto>> GetMyFavoritesAsync(int customerId);
    }
}
