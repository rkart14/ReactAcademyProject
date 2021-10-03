using RestaurantManagementSystem.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Infrastructure.Interfaces
{
    public interface IAccountService
    {
        public Task<AuthenticationResult> Authenticate(AuthenticateInput input);

        public Task<RestaurantRegisterResult> Register(RestaurantRegisterInput input);
    }
}
