using CoachBuddy.Application.ApplicationUser;
using CoachBuddy.Application.Client.Commands.CreateClient;
using CoachBuddy.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
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
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
            services.AddMediatR(typeof(CreateClientCommand));

            services.AddAutoMapper(typeof(ClientMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateClientCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
