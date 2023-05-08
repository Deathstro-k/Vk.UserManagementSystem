using Vk.UserManagementSystem.Domain.Codes;
namespace Vk.UserManagementSystem.Domain.Entities;
public class UserGroup
{
    public Guid Id { get; set; }

    public UserGroupCode Code { get; set; }

    public string? Description { get; set; }  
}