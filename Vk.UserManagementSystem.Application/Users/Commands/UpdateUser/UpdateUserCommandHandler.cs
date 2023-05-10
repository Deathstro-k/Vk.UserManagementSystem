using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.UserManagementSystem.Application.Common.Exceptions;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Domain.Codes;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand,Unit>
{
    private readonly IUserManagementSystemDbContext _db;

    public UpdateUserCommandHandler(IUserManagementSystemDbContext db) => _db = db;
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _db.Users
            .Include(group => group.UserGroup)
            .Include(state => state.UserState).FirstOrDefaultAsync(user =>
                user.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        var adminsCount = _db.Users.Count(user => user.UserGroup.Code == UserGroupCode.Admin);
        if (adminsCount == 1 && request.UserGroupCode == UserGroupCode.Admin)
        {
            throw new AdminsCountException();
        }    

        entity.Login = request.Login;
        entity.Password = request.Password;
        entity.UserGroup = _db.UserGroups.FirstOrDefault(group => group.Code == request.UserGroupCode);
        //entity.UserState = _db.UserStates.FirstOrDefault(state => state.Code == request.UserStateCode);
        
        await _db.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
