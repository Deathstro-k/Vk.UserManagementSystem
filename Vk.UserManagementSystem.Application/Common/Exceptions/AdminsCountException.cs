namespace Vk.UserManagementSystem.Application.Common.Exceptions;

public class AdminsCountException : Exception{
    public AdminsCountException()
    : base($"There can be only one administrator.") { }
}

