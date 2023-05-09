using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vk.UserManagementSystem.Domain.Codes;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Persistence.Configurations;
public class UserStateConfiguration : IEntityTypeConfiguration<UserState>
{
    public void Configure(EntityTypeBuilder<UserState> builder)
    {
        builder.HasData(
             new UserState { Id = Guid.NewGuid(), Code = UserStateCode.Active, Description = null },
             new UserState { Id = Guid.NewGuid(), Code = UserStateCode.Blocked, Description = "Deleted account"});
    }
}
