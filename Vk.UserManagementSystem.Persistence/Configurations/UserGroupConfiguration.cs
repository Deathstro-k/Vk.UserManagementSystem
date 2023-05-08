using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Persistence.Configurations;
public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {

    }
}
