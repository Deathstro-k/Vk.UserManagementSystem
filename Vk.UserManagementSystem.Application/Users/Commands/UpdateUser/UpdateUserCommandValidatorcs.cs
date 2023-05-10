using FluentValidation;
using Vk.UserManagementSystem.Application.Interfaces;

namespace Vk.UserManagementSystem.Application.Users.Commands.UpdateUser;
public class UpdateUserCommandValidators : AbstractValidator<UpdateUserCommand>
{
    private readonly IUserManagementSystemDbContext _db;
    public UpdateUserCommandValidators(IUserManagementSystemDbContext db)
    {
        _db = db;


        RuleFor(command => command.Id).NotEqual(Guid.Empty);

        RuleFor(command => command.Login).Matches("^[a-zA-Z0-9]+$")
            .Must((db, login) => !_db.Users.Any(user => user.Login == login))
            .MinimumLength(4)
            .MaximumLength(50);

        RuleFor(command => command.Password).Matches("^[a-zA-Z0-9]+$")
                                            .MinimumLength(8)
                                            .MaximumLength(16);

        RuleFor(command => command.UserGroupCode).NotNull().IsInEnum();
        RuleFor(command => command.UserStateCode).NotNull().IsInEnum();
    }
}
