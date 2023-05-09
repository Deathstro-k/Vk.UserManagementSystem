using MediatR;

namespace Vk.UserManagementSystem.Application.Users.ViewModels;

public class GetUserDetailsByIdQuery : IRequest<UserDetailsViewModel>
{
    public Guid Id { get; set; }
}
