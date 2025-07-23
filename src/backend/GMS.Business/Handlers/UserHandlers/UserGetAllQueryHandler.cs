using GMS.Data.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GMS.Models.ViewModels.UserViews;
using GMS.Models.Security;
using GMS.Business.ConfigurationOptions;
using GMS.Data.Repositories;

namespace GMS.Business.Handlers.UserHandlers;

public class UserGetAllQueryHandler : BaseUserHandler, IRequestHandler<UserGetAllQuery, IEnumerable<UserViewModel>>
{
    public UserGetAllQueryHandler(IUnitOfWork unitOfWork, ICustomMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager, IUserIdentity currentUser)
        : base(unitOfWork, mapper, userManager, roleManager, currentUser)
    {
    }

    public async Task<IEnumerable<UserViewModel>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
    {
        var users = await _userManager.Users.AsNoTracking().ToListAsync(cancellationToken);
        return users.Select(user => (UserViewModel)_mapper.Map<UserViewModel>(user)).AsEnumerable();
    }
}