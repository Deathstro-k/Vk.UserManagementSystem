using AutoMapper;
using Vk.UserManagementSystem.Application.Common.Mappings;
using Vk.UserManagementSystem.Application.Users.Commands.UpdateUser;
using Vk.UserManagementSystem.Domain.Codes;

namespace Vk.UserManagementSystem.API.Models;

public class UpdateUserDto : IMapWith<UpdateUserCommand>
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string UserGroupCode { get; set; }
    public string UserStateCode { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
            .ForMember(userCommand => userCommand.Login,
                opt => opt.MapFrom(userDto => userDto.Login))
              .ForMember(userCommand => userCommand.Password,
                opt => opt.MapFrom(userDto => userDto.Password))
              .ForMember(userCommand => userCommand.UserGroupCode,
                opt => opt.MapFrom(userDto => userDto.UserGroupCode))
              .ForMember(userCommand => userCommand.UserStateCode,
                opt => opt.MapFrom(userDto => userDto.UserStateCode));
    }
}
