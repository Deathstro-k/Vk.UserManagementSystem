using Microsoft.EntityFrameworkCore;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Domain.Entities;
using Vk.UserManagementSystem.Persistence.Configurations;

namespace Vk.UserManagementSystem.Persistence;
public class UserManagementSystemDbContext : DbContext, IUserManagementSystemDbContext
{
	public UserManagementSystemDbContext(DbContextOptions<UserManagementSystemDbContext> options) : base(options) { }

	public DbSet<User> Users { get; set; }
    public DbSet<UserState> UserStates { get; set; }
    public DbSet<UserGroup> UserGroup { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration())
               .ApplyConfiguration(new UserGroupConfiguration())
               .ApplyConfiguration(new UserStateConfiguration());

        base.OnModelCreating(builder);    
    }
}
