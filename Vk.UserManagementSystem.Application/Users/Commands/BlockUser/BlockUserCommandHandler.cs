using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.UserManagementSystem.Application.Common.Exceptions;
using Vk.UserManagementSystem.Application.Interfaces;
using Vk.UserManagementSystem.Application.Users.Commands.BlockUser;
using Vk.UserManagementSystem.Domain.Codes;
using Vk.UserManagementSystem.Domain.Entities;

namespace Vk.UserManagementSystem.Application.Users.Commands.BlockUser;

public class BlockUserCommandHandler : IRequestHandler<BlockUserCommand>
{
    private readonly IUserManagementSystemDbContext _db;
    public BlockUserCommandHandler(IUserManagementSystemDbContext db) => _db = db;
    public async Task Handle(BlockUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _db.Users.Include(state => state.UserState).FirstOrDefaultAsync(user =>
                user.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }
        entity.UserStateId = _db.UserStates.FirstOrDefault(u=>u.Code==UserStateCode.Blocked).Id;

        await _db.SaveChangesAsync(cancellationToken);        
    }
}
