using Vk.UserManagementSystem.Persistence;

namespace Vk.UserManagementSystem.Tests.Common;
public abstract class TestCommandBase : IDisposable
{
    protected readonly UserManagementSystemDbContext context;
    public TestCommandBase() => context = UserManagmentSystemContextFactory.Create();
    public void Dispose() => UserManagmentSystemContextFactory.Initial(context);
}
