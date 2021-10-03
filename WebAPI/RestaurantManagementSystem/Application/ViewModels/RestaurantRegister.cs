using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.ViewModels
{
    public class RestaurantRegisterResult
    {
        public Guid  RestaurantId { get; set; }

        public string AuthToken { get; set; }


    }

    public class RestaurantRegisterInput
    {
        public string ManagerName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
