using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vk.UserManagementSystem.Application.Common.Behaviors;

namespace Vk.UserManagementSystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services) => services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() })
            .AddTransient(typeof(IPipelineBehavior <,>), typeof(ValidatorBehavior <,>))
            .AddMemoryCache();
    
            
}