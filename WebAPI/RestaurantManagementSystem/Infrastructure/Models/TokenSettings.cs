using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Infrastructure.Models
{
    public class TokenSettings
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Key { get; set; }

        public int ExpirationTimeInMinutes { get; set; }

    }
}
