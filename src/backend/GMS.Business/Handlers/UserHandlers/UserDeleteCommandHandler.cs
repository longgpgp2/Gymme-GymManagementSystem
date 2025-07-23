using GMS.Business.ConfigurationOptions;
using GMS.Core.Exceptions;
using GMS.Data.Repositories;
using GMS.Data.UnitOfWorks;
using GMS.Models.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GMS.Business.Handlers.UserHandlers;

public class UserDeleteCommandHandler : BaseUserHandler, IRequestHandler<UserDeleteCommand, bool>
{
    public UserDeleteCommandHandler(IUnitOfWork unitOfWork, ICustomMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager, IUserIdentity currentUser)
    : base(unitOfWork, mapper, userManager, roleManager, currentUser) { }

    public async Task<bool> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString()) ??
            throw new ResourceNotFoundException("User not found");

        user.IsDeleted = true;
        user.DeletedAt = DateTime.UtcNow;
        user.DeletedById = _currentUser.UserId;
        user.IsActive = false;
        user.UpdatedAt = DateTime.UtcNow;
        user.UpdatedById = _currentUser.UserId;

        return await _userManager.UpdateAsync(user) == IdentityResult.Success;
    }
}