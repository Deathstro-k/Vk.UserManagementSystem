using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vk.UserManagementSystem.API.Models;
using Vk.UserManagementSystem.API.Controllers.Base;
using Vk.UserManagementSystem.Application.Users.Queries;
using Vk.UserManagementSystem.Application.Users.ViewModels;
using Vk.UserManagementSystem.Application.Users.Commands.BlockUser;
using Vk.UserManagementSystem.Application.Users.Commands.UpdateUser;
using Vk.UserManagementSystem.Application.Users.Commands.CreateUser;
using Vk.UserManagementSystem.Application.Users.Queries.GetUserDetails;
using Vk.UserManagementSystem.Application.Users.Queries.GetUserDetailsPagination;

namespace Vk.UserManagementSystem.API.Controllers;
public class UserController : BaseController
{
    
    private readonly IMapper _mapper;    
    public UserController(IMapper mapper) => _mapper = mapper;
    
    [HttpGet]
    public async Task<ActionResult<UserDetailsListViewModel>> GetAll()
    {
        var query = new GetUserPaginationQuery();
    
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public async Task<ActionResult<UserDetailsListViewModel>> GetPage(int pageNumber,int pageSize)
    {
        var query = new GetUserPageQuery
        {
             PageNumber = pageNumber,
             PageSize = pageSize
        };

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDetailsViewModel>> Get(Guid id)
    {
        var query = new GetUserDetailsByIdQuery
        {
            Id = id  
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateUserDto createUserDto)
    { 
        var command = _mapper.Map<CreateUserCommand>(createUserDto);
        var userId = await Mediator.Send(command);
        return Ok(userId);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
    {
        var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Block(Guid id)
    {
        var command = new BlockUserCommand { Id = id };
        await Mediator.Send(command);
        return NoContent();
    }
}
