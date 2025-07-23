using GMS.Business.ConfigurationOptions;
using GMS.Core.Exceptions;
using GMS.Data.Repositories;
using GMS.Data.UnitOfWorks;
using GMS.Models.Security;
using GMS.Models.ViewModels.UserViews;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GMS.Business.Handlers.UserHandlers;

public class UserGetByIdQueryHandler : BaseUserHandler, IRequestHandler<UserGetByIdQuery, UserViewModel>
{
    public UserGetByIdQueryHandler(IUnitOfWork unitOfWork, ICustomMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager, IUserIdentity currentUser)
        : base(unitOfWork, mapper, userManager, roleManager, currentUser)
    {
    }

    public async Task<UserViewModel> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString()) ??
                   throw new ResourceNotFoundException($"User with ID {request.Id} not found.");

        return (UserViewModel)_mapper.Map<UserViewModel>(user);
    }
}
