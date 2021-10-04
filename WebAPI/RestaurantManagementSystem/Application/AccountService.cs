using RestaurantManagementSystem.Application.ViewModels;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Helpers;
using RestaurantManagementSystem.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository userRepository;
        private readonly IRestaurantRepository restaurantRepository;
        private readonly IJwtSecurityTokenGenerator jwtSecurityTokenGenerator;

        public AccountService(IUserRepository userRepository, IRestaurantRepository restaurantRepository, IJwtSecurityTokenGenerator jwtSecurityTokenGenerator)
        {
            this.userRepository = userRepository;
            this.restaurantRepository = restaurantRepository;
            this.jwtSecurityTokenGenerator = jwtSecurityTokenGenerator;
        }

        public async Task<AuthenticationResult> Authenticate(AuthenticateInput input)
        {
            var user = await userRepository.Get(input.Email, PasswordHashier.Hash(input.Password));
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
            };

            return await Task.FromResult(new AuthenticationResult
            {
                Token = jwtSecurityTokenGenerator.Generate(claims),
                Email = user.Email,
                IsInitialized = user.Restaurant.IsInitialized(),
                RestaurantName = user.Restaurant.Name
            });
        }

        public async Task<RestaurantRegisterResult> Register(RestaurantRegisterInput input)
        {
            var user = new User
            {
                Email = input.Email,
                Password = PasswordHashier.Hash(input.Password),
                Name = input.ManagerName,
            };
            var restaurant = new Restaurant
            {
                Manager = user,
                ManagerEmail = user.Email,
            };
            user.Restaurant = restaurant;
            user.RestaurantId = restaurant.Id;
            var savedRestaurant = await userRepository.Create(user);
            await restaurantRepository.Add(restaurant);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
            };

            return await Task.FromResult(new RestaurantRegisterResult
            {
                RestaurantId = savedRestaurant.Id,
                AuthToken = jwtSecurityTokenGenerator.Generate(claims)
            });
        }
    }
}
