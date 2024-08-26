using CoachBuddy.Infrastructure.Persistence;
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
        }
    }
}
