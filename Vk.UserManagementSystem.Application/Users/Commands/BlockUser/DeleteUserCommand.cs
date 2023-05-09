using MediatR;

namespace Vk.UserManagementSystem.Application.Users.Commands.BlockUser;
public class BlockUserCommand : IRequest
{
    public Guid Id { get; set; }
}
