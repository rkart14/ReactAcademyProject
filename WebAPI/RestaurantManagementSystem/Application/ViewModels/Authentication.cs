using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.ViewModels
{
    public class AuthenticationResult
    {
        public string Email { get; set; }

        public string RestaurantName { get; set; }

        public bool IsInitialized { get; set; }

        public string Token { get; set; }

    }

    public class AuthenticateInput
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
