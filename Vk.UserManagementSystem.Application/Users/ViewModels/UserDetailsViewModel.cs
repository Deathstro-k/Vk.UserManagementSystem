using AutoMapper;
using Vk.UserManagementSystem.Application.Common.Mappings;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Application.Users.ViewModels;

public class UserDetailsViewModel:IMapWith<User>
{
    public string Login { get; set; }

    public string Password { get; set; }

    public DateTime Created_date { get; set; }

    public string UserGroupCode { get; set; }
    
    public string? UserGroupDescription { get; set; }    

    public string UserStateCode { get; set; }

    public string? UserStateDescription { get; set; }

    public void Mapping(Profile profile) 
    {
        profile.CreateMap<User, UserDetailsViewModel>()
            .ForMember(uservm => uservm.Login,
                options => options.MapFrom(user => user.Login))
            .ForMember(uservm => uservm.Password,
                options => options.MapFrom(user => user.Password))
            .ForMember(uservm => uservm.Created_date,
                options => options.MapFrom(user => user.CreatedDate))
            .ForMember(uservm => uservm.UserGroupCode,
                options => options.MapFrom(user => user.UserGroup.Code))
            .ForMember(uservm => uservm.UserGroupDescription,
                options => options.MapFrom(user => user.UserGroup.Description))
            .ForMember(uservm => uservm.UserStateCode,
                options => options.MapFrom(user => user.UserState.Code))
            .ForMember(uservm => uservm.UserStateDescription,
                options => options.MapFrom(user => user.UserState.Description));
    }
}
