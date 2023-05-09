using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vk.UserManagementSystem.Application.Interfaces;

namespace Vk.UserManagementSystem.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) => services
        .AddDbContext<IUserManagementSystemDbContext,UserManagementSystemDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("PostgreSQL");
            options.UseNpgsql(connectionString);
        });     
}
