using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.UserManagementSystem.Application.Common.Exceptions;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Application.Users.ViewModels;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Application.Users.Queries.GetUserDetails;
public class GetUserDetailsByIdQueryHandler : IRequestHandler<GetUserDetailsByIdQuery, UserDetailsViewModel>
{
    private readonly IUserManagementSystemDbContext _db;

    private readonly IMapper _mapper;

    public GetUserDetailsByIdQueryHandler(IUserManagementSystemDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<UserDetailsViewModel> Handle(GetUserDetailsByIdQuery request,CancellationToken cancellationToken)
    {
        var userDetails = await _db.Users.Include(u => u.UserGroup).Include(u => u.UserState).FirstOrDefaultAsync(u => u.Id == request.Id);
            //.Join(_db.UserGroups,
            //      user=>user.UserGroupId,
            //      group=>group.Id,
            //      (user,group)=> new { user, group }
            //      )
            // .Join(_db.UserStates,
            //      table => table.user.UserStateId,
            //      state => state.Id,
            //      (state, table) => new User
            //                        {}
            //      ).FirstOrDefaultAsync(s => s.state.user.Id == request.Id,cancellationToken);

        if (userDetails == null) throw new NotFoundException(nameof(User), request.Id);
        return _mapper.Map<UserDetailsViewModel>(userDetails);
    }
}
