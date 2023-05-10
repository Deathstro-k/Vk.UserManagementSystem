

namespace Vk.UserManagementSystem.Application.Common.Exceptions;

public class CreateCommandTimeoutException:Exception
{
    public CreateCommandTimeoutException(string name,TimeSpan timeout)
    : base($"You cannot add entity \"{name}\" within {timeout.Seconds} seconds.") { }
}
