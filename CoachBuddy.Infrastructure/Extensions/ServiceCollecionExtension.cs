using CoachBuddy.Domain.Interfaces;
using CoachBuddy.Infrastructure.Persistence;
using CoachBuddy.Infrastructure.Repositories;
using CoachBuddy.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Infrastructure.Extensions
{
    public static class ServiceCollecionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<CoachBuddyDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("CoachBuddy")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CoachBuddyDbContext>();

            services.AddScoped<CoachBuddySeeder>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientTrainingRepository, ClientTrainingRepository>();
        }
    }
}
