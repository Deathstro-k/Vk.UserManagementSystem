using Microsoft.EntityFrameworkCore;
using Vk.UserManagementSystem.Domain.Codes;
using Vk.UserManagementSystem.Domain.Entities;
using Vk.UserManagementSystem.Persistence;

namespace Vk.UserManagementSystem.Tests.Common;

public class UserManagmentSystemContextFactory
{  
    public static UserManagementSystemDbContext Create()
    {
        var options = new DbContextOptionsBuilder<UserManagementSystemDbContext>()
            .UseInMemoryDatabase("MemoryDB")
            .Options;
        var context = new UserManagementSystemDbContext(options);
        context.Database.EnsureCreated();
        //context.UserStates.AddRange(
        //    new UserState
        //    {                
        //        Id = Guid.Parse("SSSSSSSS-5AC2-4AFA-8A28-2616F675AAAA"),
        //        Code = UserStateCode.Active,
        //        Description=null
                
        //    },
        //    new UserState
        //    {
        //        Id = Guid.Parse("SSSSSSSS-5AC2-4AFA-8A28-2616F675BBBB"),
        //        Code = UserStateCode.Blocked,
        //        Description = "Deleted account"
        //    }            
        //);
        //context.UserGroups.AddRange(
        //    new UserGroup
        //    {
        //        Id = Guid.Parse("GGGGGGGG-5AC2-4AFA-8A28-2616F675AAAA"),
        //        Code = UserGroupCode.User,
        //        Description = null
        //    },
        //    new UserGroup
        //    {
        //        Id = Guid.Parse("GGGGGGGG-5AC2-4AFA-8A28-2616F675BBBB"),
        //        Code = UserGroupCode.Admin,
        //        Description = "God mode"
        //    }
        //);
        context.SaveChanges();
        return context;
    }

    public static void Initial(UserManagementSystemDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}

