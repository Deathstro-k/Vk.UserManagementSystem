using AutoMapper;
using Vk.UserManagementSystem.Application.Common.Mappings;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Persistence;
using Xunit;

namespace Vk.UserManagementSystem.Tests.Common;

public class QueryTestFixture : IDisposable
{
    public UserManagementSystemDbContext Context;
    public IMapper Mapper;

    public QueryTestFixture()
    {
        Context = UserManagmentSystemContextFactory.Create();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AssemblyMappingProfile(
                typeof(IUserManagementSystemDbContext).Assembly));
        });
        Mapper = configurationProvider.CreateMapper();
    }

    public void Dispose()
    {
        UserManagmentSystemContextFactory.Initial(Context);
    }
}

[CollectionDefinition("QueryCollection")]
public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
