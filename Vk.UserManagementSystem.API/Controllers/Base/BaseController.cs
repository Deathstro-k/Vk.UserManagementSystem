using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vk.UserManagementSystem.API.Controllers.Base;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController:ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


}
