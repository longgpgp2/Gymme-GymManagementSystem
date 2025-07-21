using GMS.Data.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using GMS.Models.Security;
using GMS.Business.ConfigurationOptions;
using GMS.Business.Handlers.Base;

namespace GMS.Business.Handlers.UserHandlers;

public class BaseUserHandler : BaseHandler
{
    protected readonly UserManager<User> _userManager;
    protected readonly RoleManager<Role> _roleManager;

    public BaseUserHandler(IUnitOfWork unitOfWork, ICustomMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
        : base(unitOfWork, mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
}
