using Microsoft.Extensions.DependencyInjection;
using RestaurantManagementSystem.Application;
using RestaurantManagementSystem.Data.InMemoryManagers;
using RestaurantManagementSystem.Helpers;
using RestaurantManagementSystem.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Infrastructure
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAccountService, AccountService>();
            serviceCollection.AddTransient<ITableManagementService, TableManagementService>();
            serviceCollection.AddTransient<IReportingService, ReportingService>();
            serviceCollection.AddTransient<IReservationService, ReservationService>();

            serviceCollection.AddTransient<IRestaurantRepository, RestaurantInMemoryManager>();
            serviceCollection.AddTransient<IUserRepository, UserInMemoryManager>();

            serviceCollection.AddTransient<IJwtSecurityTokenGenerator, JwtSecurityTokenGenerator>();

            return serviceCollection;
        }
    }
}
