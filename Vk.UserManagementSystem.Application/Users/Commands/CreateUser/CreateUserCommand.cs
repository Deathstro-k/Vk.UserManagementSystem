using MediatR;

namespace Vk.UserManagementSystem.Application.Users.Commands.CreateUser;
public class CreateUserCommand:IRequest<Guid>
{
    public Guid UserId { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }
}
