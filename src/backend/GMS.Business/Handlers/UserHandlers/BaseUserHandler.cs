using GMS.Data.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using GMS.Models.Security;
using GMS.Business.ConfigurationOptions;
using GMS.Business.Handlers.Base;
using GMS.Data.Repositories;

namespace GMS.Business.Handlers.UserHandlers;

public class BaseUserHandler(IUnitOfWork unitOfWork, ICustomMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager, IUserIdentity currentUser) : BaseHandler(unitOfWork, mapper)
{
    protected readonly UserManager<User> _userManager = userManager;
    protected readonly RoleManager<Role> _roleManager = roleManager;
    protected readonly IUserIdentity _currentUser = currentUser;
}
