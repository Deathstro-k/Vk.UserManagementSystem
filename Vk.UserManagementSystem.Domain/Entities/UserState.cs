using Vk.UserManagementSystem.Domain.Codes;
namespace Vk.UserManagementSystem.Domain.Entities;
public class UserState
{   
    public Guid Id { get; set; }
    public UserStateCode Code { get; set; }
    public string? Description { get; set; }
    public ICollection<User> Users { get; set; }
}