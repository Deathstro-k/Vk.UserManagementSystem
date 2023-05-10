using FluentValidation;
using Vk.UserManagementSystem.Application.Interfaces;

namespace Vk.UserManagementSystem.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
{
    private readonly IUserManagementSystemDbContext _db;
    public CreateUserCommandValidator(IUserManagementSystemDbContext db)
	{
		_db = db;	
		
		RuleFor(command => command.Login).Matches("^[a-zA-Z0-9]+$")
			.Must((db,login) => !_db.Users.Any(user=>user.Login==login));

        RuleFor(command => command.Password).Matches("^[a-zA-Z0-9]+$")
										 .MinimumLength(8)
										 .MaximumLength(16);
    }
}
