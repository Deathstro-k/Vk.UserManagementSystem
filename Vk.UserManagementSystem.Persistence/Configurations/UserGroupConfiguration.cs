using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Vk.UserManagementSystem.Domain.Entities;
using Vk.UserManagementSystem.Domain.Codes;

namespace Vk.UserManagementSystem.Persistence.Configurations;
public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.HasData(
            new UserGroup { Id = Guid.NewGuid(), Code = UserGroupCode.User, Description = null },
            new UserGroup { Id = Guid.NewGuid(), Code = UserGroupCode.Admin, Description = "Only one" });
    }
}
