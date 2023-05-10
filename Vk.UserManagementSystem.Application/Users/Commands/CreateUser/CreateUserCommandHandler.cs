using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Vk.UserManagementSystem.Application.Common.Exceptions;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Domain.Codes;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Application.Users.Commands.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserManagementSystemDbContext _db;
    private readonly IMemoryCache _cache;

    public CreateUserCommandHandler(IUserManagementSystemDbContext db,IMemoryCache cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Login = request.Login,
            Password = request.Password,
            CreatedDate = DateTime.UtcNow,
            UserGroup = _db.UserGroups.FirstOrDefault(group => group.Code == UserGroupCode.User),
            UserState = _db.UserStates.FirstOrDefault(group => group.Code == UserStateCode.Active)
        };
        var timeout = TimeSpan.FromSeconds(5);
        if (_cache.TryGetValue(user.Login, out _))
        {
            throw new CreateCommandTimeoutException(nameof(User),timeout);
        }

        _cache.Set(user.Login, "", new MemoryCacheEntryOptions().SetAbsoluteExpiration(timeout));


        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}
