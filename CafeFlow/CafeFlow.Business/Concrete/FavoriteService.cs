using AutoMapper;
using CafeFlow.Business.Abstract;
using CafeFlow.DataAccess.Repositories.Customers;
using CafeFlow.DataAccess.Repositories.Favorites;
using CafeFlow.DTO.Favorite;
using CafeFlow.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeFlow.Business.Concrete
{
    public class FavoriteService(ICustomerRepository _customerRepository, IFavoriteRepository _favoriteRepository, IMapper _mapper) : IFavoriteService
    {
        public async Task<List<FavoriteProductDto>> GetMyFavoritesAsync(int customerId)
        {
            var customer = await _customerRepository.GetByAppUserIdAsync(customerId);
            if (customer is null) return [];
            var favorites = await _favoriteRepository.GetFavoritesWithProductByCustomerAsync(customer.Id);
            return _mapper.Map<List<FavoriteProductDto>>(favorites);

        }

        public async Task<HashSet<int>> GetUserFavoriteProductIdsAsync(int customerId)
        {
            var customer = await _customerRepository.GetByAppUserIdAsync(customerId);
            if (customer is null) return [];

            var ids = await _favoriteRepository.GetFavoriteProductIdsByCustomerAsync(customer.Id);
            return [.. ids];
        }

        public async Task<bool> ToggleFavoriteAsync(int customerId, int productId)
        {
            var customer = await _customerRepository.GetByAppUserIdAsync(customerId);
            var existing = await _favoriteRepository.GetByCustomerAndProductAsync(customer.Id, productId);

            if(existing is not null)
            {
                await _favoriteRepository.HardDeleteAsync(existing);
                return false;
            }

            await _favoriteRepository.CreateAsync(new Favorite
            {
                CustomerId = customer.Id,
                ProductId = productId
            });

            return true;
        }
    }
}
