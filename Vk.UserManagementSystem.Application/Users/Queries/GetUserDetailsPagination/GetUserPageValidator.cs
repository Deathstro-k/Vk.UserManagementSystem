using FluentValidation;

namespace Vk.UserManagementSystem.Application.Users.Queries.GetUserDetailsPagination;
public class GetUserPageValidator : AbstractValidator<GetUserPageQuery>
{
    public GetUserPageValidator()
    {
        RuleFor(query=>query.PageNumber).NotNull().GreaterThan(0);
        RuleFor(query => query.PageNumber).NotNull().GreaterThan(0);
    }
}
