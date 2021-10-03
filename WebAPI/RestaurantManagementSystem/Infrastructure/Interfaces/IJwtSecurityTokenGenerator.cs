using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Infrastructure.Interfaces
{
    public interface IJwtSecurityTokenGenerator
    {
        string Generate(List<Claim> claims);
    }

}
