using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vk.UserManagementSystem.API.Controllers.Base;
using Vk.UserManagementSystem.Application.Users.Queries;
using Vk.UserManagementSystem.Application.Users.ViewModels;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.API.Controllers;

public class UserController : BaseController
{
    
    private readonly IMapper _mapper;
    
    public UserController(IMapper mapper) => _mapper = mapper;
    
    [HttpGet]
    public async Task<ActionResult<UserDetailsListViewModel>> GetAll()
    {
        var query = new GetUserDetailsListQuery();
    
        var vm = await Mediator.Send(query);
        return vm;
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
}
