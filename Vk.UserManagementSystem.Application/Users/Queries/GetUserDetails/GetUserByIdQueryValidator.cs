using FluentValidation;

namespace Vk.UserManagementSystem.Application.Users.Queries.GetUserDetails;
public class GetUserByIdQueryValidator : AbstractValidator<GetUserDetailsByIdQuery>
{   
    public GetUserByIdQueryValidator()
    {
        RuleFor(user => user.Id).NotEqual(Guid.Empty);
    }
}