﻿using Application.Contracts.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServicesRegisteration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
                configuration.GetConnectionString("AppConnectionString")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
