using MediatR;
using Vk.UserManagementSystem.Application.Users.ViewModels;

namespace Vk.UserManagementSystem.Application.Users.Queries.GetUserDetails;

public class GetUserDetailsByIdQuery : IRequest<UserDetailsViewModel>
{
    public Guid Id { get; set; }
}
