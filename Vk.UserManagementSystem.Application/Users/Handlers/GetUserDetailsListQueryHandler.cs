using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Application.Users.Queries;
using Vk.UserManagementSystem.Application.Users.ViewModels;

namespace Vk.UserManagementSystem.Application.Users.Handlers;

public class GetUserDetailsListQueryHandler : IRequestHandler<GetUserDetailsListQuery, UserDetailsListViewModel>
{
    private readonly IUserManagementSystemDbContext _db;
    private readonly IMapper _mapper;
    public GetUserDetailsListQueryHandler(IUserManagementSystemDbContext db,
        IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<UserDetailsListViewModel> Handle(GetUserDetailsListQuery request,
        CancellationToken cancellationToken)
    {
        var userDetailsList = await _db.Users
            .ProjectTo<UserDetailsViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new UserDetailsListViewModel { UserDetailsList = userDetailsList };
    }
}

