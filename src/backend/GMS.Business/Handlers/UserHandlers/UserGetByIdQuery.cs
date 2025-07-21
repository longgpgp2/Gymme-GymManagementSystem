using System;
using GMS.Business.ConfigurationOptions;
using GMS.Data.UnitOfWorks;
using GMS.Models.Security;
using GMS.Models.ViewModels.UserViews;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GMS.Business.Handlers.UserHandlers;

public class UserGetByIdQuery : IRequest<UserViewModel>
{
    public Guid Id { get; set; }



}

public class UserGetByIdQueryHandler : BaseUserHandler, IRequestHandler<UserGetByIdQuery, UserViewModel>
{
    public UserGetByIdQueryHandler(IUnitOfWork unitOfWork, ICustomMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager)
        : base(unitOfWork, mapper, userManager, roleManager)
    {
    }

    public async Task<UserViewModel> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString()) ??
                   throw new KeyNotFoundException($"User with ID {request.Id} not found.");

        return (UserViewModel)_mapper.Map<UserViewModel>(user);
    }
}
