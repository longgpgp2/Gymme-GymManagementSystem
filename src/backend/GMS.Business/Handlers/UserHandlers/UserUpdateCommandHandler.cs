using GMS.Models.ViewModels.UserViews;
using MediatR;
using GMS.Data.UnitOfWorks;
using GMS.Business.ConfigurationOptions;
using Microsoft.AspNetCore.Identity;
using GMS.Models.Security;
using GMS.Data.Repositories;

namespace GMS.Business.Handlers.UserHandlers;

public class UserUpdateCommandHandler : BaseUserHandler, IRequestHandler<UserUpdateCommand, UserViewModel>
{
    public UserUpdateCommandHandler(IUnitOfWork unitOfWork, ICustomMapper mapper, UserManager<User> userManager, RoleManager<Role> roleManager, IUserIdentity currentUser) : base(unitOfWork, mapper, userManager, roleManager, currentUser)
    {
    }

    public async Task<UserViewModel> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.Id == request.Id) ??
            throw new KeyNotFoundException("User not found.");


        user.FullName = request.FullName ?? user.FullName;
        user.Gender = request.Gender;
        user.Email = request.Email ?? user.Email;
        user.JoinDate = request.JoinDate ?? user.JoinDate;
        user.HireDate = request.HireDate ?? user.HireDate;
        user.Salary = request.Salary ?? user.Salary;
        user.TotalSales = request.TotalSales ?? user.TotalSales;
        user.Commission = request.Commission ?? user.Commission;
        user.Certificate = request.Certificate ?? user.Certificate;
        user.PackageEndDate = request.PackageEndDate ?? user.PackageEndDate;
        user.EmployeeCode = request.EmployeeCode ?? user.EmployeeCode;
        user.ManagerId = request.ManagerId ?? user.ManagerId;
        user.IsActive = request.IsActive;
        user.Status = request.Status;
        user.UpdatedAt = DateTime.UtcNow;
        user.UpdatedById = _currentUser.UserId;
        user.IsDeleted = request.IsDeleted;

        await _userManager.UpdateAsync(user);

        return (UserViewModel)_mapper.Map<UserViewModel>(user);
    }
}