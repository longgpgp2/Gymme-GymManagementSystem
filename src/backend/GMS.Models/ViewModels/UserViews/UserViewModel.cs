using System;
using GMS.Models.ViewModels.Base;
using GMS.Models.Enums;

namespace GMS.Models.ViewModels.UserViews;

public class UserViewModel : BaseInfoViewModel
{
    public string? FullName { get; set; }

    public Gender Gender { get; set; } = Gender.OTHER;

    public string? Email { get; set; }

    public DateTime? JoinDate { get; set; }

    public DateTime? HireDate { get; set; }

    public decimal? Salary { get; set; }

    public decimal? TotalSales { get; set; }

    public decimal? Commission { get; set; }

    public string? Certificate { get; set; }

    public DateTime? PackageEndDate { get; set; }

    public string? EmployeeCode { get; set; }

    public Guid? ManagerId { get; set; }

    public string? Manager { get; set; }

    public bool IsActive { get; set; }

    public string? Status { get; set; }
}
