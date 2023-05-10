using FluentValidation;

namespace Vk.UserManagementSystem.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
{
    
    public CreateUserCommandValidator()
	{		
		RuleFor(command => command.Login).Matches("^[a-zA-Z0-9]+$")			
                                         .MinimumLength(4)
                                         .MaximumLength(50); ;

        RuleFor(command => command.Password).Matches("^[a-zA-Z0-9]+$")
										    .MinimumLength(8)
										    .MaximumLength(16);
    }
}
