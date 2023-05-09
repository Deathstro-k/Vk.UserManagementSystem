using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.UserManagementSystem.Application.Common.Exceptions;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Application.Users.ViewModels;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Application.Users.Handlers;
public class GetUserDetailsByIdQueryHandler: IRequestHandler<GetUserDetailsByIdQuery, UserDetailsViewModel>
{
    private readonly IUserManagementSystemDbContext _db;

    private readonly IMapper _mapper;
    public GetUserDetailsByIdQueryHandler(IUserManagementSystemDbContext db,
        IMapper mapper) 
    {
        _db = db;
        _mapper = mapper;   
    }
   
    public async Task<UserDetailsViewModel> Handle(GetUserDetailsByIdQuery request,
        CancellationToken cancellationToken)
    {
        var userDetails = await _db.Users.FirstOrDefaultAsync(s => s.Id == request.Id);

        if (userDetails == null) throw new NotFoundException(nameof(User),request.Id);
        return _mapper.Map<UserDetailsViewModel>(userDetails);
    }
}
