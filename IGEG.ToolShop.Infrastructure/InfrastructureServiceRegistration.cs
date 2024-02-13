﻿using IGEG.ToolShop.Application.Contracts.Email;
using IGEG.ToolShop.Application.Contracts.Email.Models;
using IGEG.ToolShop.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace IGEG.ToolShop.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService,EmailService>();
            return services;
        }
    }
}