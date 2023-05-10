using MediatR;
using Vk.UserManagementSystem.Application.Users.ViewModels;

namespace Vk.UserManagementSystem.Application.Users.Queries.GetUserDetailsPagination;
public class GetUserPageQuery:IRequest<UserPaginationListViewModel>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}