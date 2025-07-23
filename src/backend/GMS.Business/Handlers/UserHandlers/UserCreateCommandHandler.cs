using GMS.Business.ConfigurationOptions;
using GMS.Core.Exceptions;
using GMS.Data.Repositories;
using GMS.Data.UnitOfWorks;
using GMS.Models.Security;
using GMS.Models.ViewModels.UserViews;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GMS.Business.Handlers.UserHandlers;

public class UserCreateCommandHandler : BaseUserHandler, IRequestHandler<UserCreateCommand, UserViewModel>
{
    private readonly PasswordHasher<User> _passwordHasher;
    public UserCreateCommandHandler(IUnitOfWork unitOfWork, ICustomMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager, IUserIdentity currentUser)
        : base(unitOfWork, mapper, userManager, roleManager, currentUser)
    {
        _passwordHasher = new PasswordHasher<User>();
    }

    public async Task<UserViewModel> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.Username ?? throw new RequestValidationException("Username is required."),
            FullName = request.FullName ?? throw new RequestValidationException("Full Name is required."),
            Gender = request.Gender,
            Email = request.Email ?? throw new RequestValidationException("Email is required."),
            Salary = request.Salary,
            Certificate = request.Certificate,
            IsActive = request.IsActive,
            CreatedAt = DateTime.UtcNow,
            CreatedById = _currentUser.UserId,
            JoinDate = DateTime.UtcNow,
            Status = request.Status
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, "user123");
        await _userManager.CreateAsync(user);

        return (UserViewModel) _mapper.Map<UserViewModel>(user);
    }
}
