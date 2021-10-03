using Microsoft.Extensions.Caching.Memory;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Data.InMemoryManagers
{
    public class RestaurantInMemoryManager : IRestaurantRepository
    {
        private readonly IMemoryCache cache;
        private const string _restaurantCacheKey = "Restaurants";
        public RestaurantInMemoryManager(IMemoryCache cache)
        {
            this.cache = cache;
        }
        public Task<Restaurant> Add(Restaurant restaurant)
        {
            var restaurants = (List<Restaurant>)cache.Get(_restaurantCacheKey);
            if (restaurants == null)
            {
                var list = new List<Restaurant> { restaurant };
                cache.Set(_restaurantCacheKey, list);
            }
            else
            {
                restaurants.Add(restaurant);
                cache.Set(_restaurantCacheKey, restaurants);
            }
            return Task.FromResult(restaurant);
        }

        public Task<Restaurant> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
