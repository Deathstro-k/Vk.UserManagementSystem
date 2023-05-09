using AutoMapper;
using Vk.UserManagementSystem.Application.Common.Mappings;
using Vk.UserManagementSystem.Application.Users.Commands.CreateUser;

namespace Vk.UserManagementSystem.API;

public class CreateUserDto:IMapWith<CreateUserCommand>
{
    public string Login { get; set; }
    public string Password { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUserDto, CreateUserCommand>()
            .ForMember(userCommand => userCommand.Login,
                opt => opt.MapFrom(userDto => userDto.Login))
              .ForMember(userCommand => userCommand.Password,
                opt => opt.MapFrom(userDto => userDto.Password));
    }
}


