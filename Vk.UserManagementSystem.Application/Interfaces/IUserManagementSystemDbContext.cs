using Microsoft.EntityFrameworkCore;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Application.Interfaces;
public interface IUserManagementSystemDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserState> UserStates { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
