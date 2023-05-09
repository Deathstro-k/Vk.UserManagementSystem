using AutoMapper;
using MediatR;
using Vk.UserManagementSystem.Application.Common.Exceptions;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Application.Users.ViewModels;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Application.Users.Handlers;
public class GetUserDetailsByIdQueryHandler: IRequestHandler<GetUserDetailsByIdQuery, UserDetailsViewModel>
{
    private readonly IRepository<User> _userRepository;

    private readonly IMapper _mapper;
    public GetUserDetailsByIdQueryHandler(IRepository<User> repository,
        IMapper mapper) 
    {
        _userRepository = repository;
        _mapper = mapper;   
    }
   
    public async Task<UserDetailsViewModel> Handle(GetUserDetailsByIdQuery request,
        CancellationToken cancellationToken)
    {
        var userDetails = await _userRepository.GetAsync(request.Id,cancellationToken);

        if (userDetails == null) throw new NotFoundException(nameof(User),request.Id);
        return _mapper.Map<UserDetailsViewModel>(userDetails);
    }
}
