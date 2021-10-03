using Microsoft.Extensions.Caching.Memory;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Data.InMemoryManagers
{
    public class UserInMemoryManager : IUserRepository
    {
        private readonly IMemoryCache cache;
        private const string _userCacheKey= "Users";
        public UserInMemoryManager(IMemoryCache cache)
        {
            this.cache = cache;
        }
        public Task<User> Create(User user)
        {
            var users = (List<User>)cache.Get(_userCacheKey);
            if (users == null)
            {
                var list = new List<User> { user };
                cache.Set(_userCacheKey, list);
            }else
            {
                users.Add(user);
                cache.Set(_userCacheKey, users);
            }
            return Task.FromResult(user);
        }

        public Task<User> Get(string email, string password)
        {
            var users = (List<User>)cache.Get(_userCacheKey);
            if (users == null)
            {
                throw new UnauthorizedAccessException("Username or password is incorrect!");
            }
            else
            {
                var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user == null)
                {
                    throw new UnauthorizedAccessException("Username or password is incorrect!");
                }else
                {
                    return Task.FromResult(user);
                }
            }
        }
    }
}
