
using FluentValidation;

namespace Vk.UserManagementSystem.Application.Users.Queries.GetUserDetailsList;

public class GetUserDetailsListValidator:AbstractValidator<GetUserPaginationQuery>
{
	public GetUserDetailsListValidator() { }
}
