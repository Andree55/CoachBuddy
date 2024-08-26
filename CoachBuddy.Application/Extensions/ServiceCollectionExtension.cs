using CoachBuddy.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Extensions
{
    public static class ServiceCollecionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
