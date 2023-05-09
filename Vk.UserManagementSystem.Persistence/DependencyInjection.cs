﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Vk.UserManagementSystem.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) => services
        .AddDbContext<UserManagementSystemDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("PostgreSQL");
            options.UseNpgsql(connectionString);
        }); 
}
