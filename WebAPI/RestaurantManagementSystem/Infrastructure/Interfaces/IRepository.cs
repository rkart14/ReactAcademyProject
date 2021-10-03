using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Infrastructure.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> Add(Restaurant Restaurant);

        Task<Restaurant> GetById(int id);

    }

    public interface IUserRepository
    {
        Task<User> Create(User user);

        Task<User> Get(string email, string password);
    }
}
