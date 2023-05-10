using MediatR;
using Vk.UserManagementSystem.Domain.Codes;

namespace Vk.UserManagementSystem.Application.Users.Commands.UpdateUser;

public class UpdateUserCommand:IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public UserGroupCode UserGroupCode { get; set; }

    //public UserStateCode UserStateCode { get; set; }
   
}
