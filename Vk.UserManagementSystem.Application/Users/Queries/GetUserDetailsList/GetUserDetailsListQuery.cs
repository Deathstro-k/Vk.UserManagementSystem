using MediatR;
using Vk.UserManagementSystem.Application.Users.ViewModels;

namespace Vk.UserManagementSystem.Application.Users.Queries;

public class GetUserPaginationQuery : IRequest<UserDetailsListViewModel> { }
