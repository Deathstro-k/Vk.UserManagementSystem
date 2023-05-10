using FluentValidation;
namespace Vk.UserManagementSystem.Application.Users.Commands.BlockUser;

public class BlockUserCommandValidator : AbstractValidator<BlockUserCommand>
{
    public BlockUserCommandValidator()
    {   
        RuleFor(command => command.Id).NotEqual(Guid.Empty);
    }
}
