using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Persistence.Configurations;
public class UserStateConfiguration : IEntityTypeConfiguration<UserState>
{
    public void Configure(EntityTypeBuilder<UserState> builder)
    {
    }
}
