using System;
using GMS.Models.Security;
using GMS.Models.ViewModels.UserViews;

namespace GMS.Business.ConfigurationOptions;


public class CustomMapper : ICustomMapper
{
    public CustomMapper()
    {

    }

    public object Map<T>(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null");
        }

        return new UserViewModel
        {
            Id = user.Id,
            FullName = user.FullName,
            Gender = user.Gender,
            Email = user.Email,
            JoinDate = user.JoinDate,
            HireDate = user.HireDate,
            Salary = user.Salary,
            TotalSales = user.TotalSales,
            Commission = user.Commission,
            Certificate = user.Certificate,
            PackageEndDate = user.PackageEndDate,
            EmployeeCode = user.EmployeeCode,
            ManagerId = user.ManagerId,
            Manager = user.Manager?.FullName,
            CreatedAt = user.CreatedAt,
            CreatedBy = user.CreatedBy?.FullName,
            UpdatedAt = user.UpdatedAt,
            UpdatedBy = user.UpdatedBy?.FullName,
            DeletedAt = user.DeletedAt,
            DeletedBy = user.DeletedBy?.FullName,
            IsDeleted = user.IsDeleted,
            IsActive = user.IsActive,
            Status = user.Status
        };
    }
}
