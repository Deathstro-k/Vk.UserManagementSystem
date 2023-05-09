using AutoMapper;
using MediatR;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Application.Users.Queries;
using Vk.UserManagementSystem.Application.Users.ViewModels;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Application.Users.Handlers;

public class GetUserDetailsListQueryHandler : IRequestHandler<GetUserDetailsListQuery, UserDetailsListViewModel>
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;
    public GetUserDetailsListQueryHandler(IRepository<User> repository,
        IMapper mapper)
    {
        _userRepository = repository;
        _mapper = mapper;
    }

    public async Task<UserDetailsListViewModel> Handle(GetUserDetailsListQuery request,
        CancellationToken cancellationToken)
    {
        var userDetailsList = await _userRepository.GetAllAsync();
       
        return _mapper.Map<UserDetailsListViewModel>(userDetailsList);
    }
}

