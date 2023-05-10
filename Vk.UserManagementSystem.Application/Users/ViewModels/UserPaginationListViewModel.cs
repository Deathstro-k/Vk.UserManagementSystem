using AutoMapper;
using Vk.UserManagementSystem.Application.Common.Mappings;
using Vk.UserManagementSystem.Application.Users.Queries.GetUserDetailsPagination;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Application.Users.ViewModels;
public class UserPaginationListViewModel:IMapWith<GetUserPageQuery>
{
    public IList<UserDetailsViewModel> UserDetailsList { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<GetUserPageQuery, UserPaginationListViewModel>()
            .ForMember(uservm => uservm.PageNumber,
                options => options.MapFrom(user => user.PageNumber))
            .ForMember(uservm => uservm.PageSize,
                options => options.MapFrom(user => user.PageSize));
    }



}
