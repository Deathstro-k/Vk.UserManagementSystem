using MediatR;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Domain.Codes;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Application.Users.Commands.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserManagementSystemDbContext _db;

    public CreateUserCommandHandler(IUserManagementSystemDbContext db) => _db = db;

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

        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
