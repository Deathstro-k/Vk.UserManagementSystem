using Vk.UserManagementSystem.Application.Common.Mappings;
using System.Reflection;
using Vk.UserManagementSystem.Persistence;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Application;

namespace Vk.UserManagementSystem.API;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        // Add services to the container.
        // builder.Services.AddApplication();
       
        services.AddAutoMapper(configuration =>
        {
            configuration.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));  
            configuration.AddProfile(new AssemblyMappingProfile(typeof(IUserManagementSystemDbContext).Assembly));    
        });
        services.AddPersistence(builder.Configuration);
        services.AddApplication();   
        

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}