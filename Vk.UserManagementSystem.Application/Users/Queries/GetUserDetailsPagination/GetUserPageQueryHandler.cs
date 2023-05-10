using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Application.Users.ViewModels;

namespace Vk.UserManagementSystem.Application.Users.Queries.GetUserDetailsPagination;
public class GetUserPageQueryHandler : IRequestHandler<GetUserPageQuery, UserPaginationListViewModel>
{

    private readonly IUserManagementSystemDbContext _db;
    private readonly IMapper _mapper; 

    public GetUserPageQueryHandler(IUserManagementSystemDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<UserPaginationListViewModel> Handle(GetUserPageQuery request, CancellationToken cancellationToken)
    {
        var userDetailsList = await _db.Users
            .ProjectTo<UserDetailsViewModel>(_mapper.ConfigurationProvider)
            .Skip((request.PageNumber-1)*request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new UserPaginationListViewModel
        {
            UserDetailsList = userDetailsList,
            PageNumber=request.PageNumber,
            PageSize=request.PageSize
        };
    }
}