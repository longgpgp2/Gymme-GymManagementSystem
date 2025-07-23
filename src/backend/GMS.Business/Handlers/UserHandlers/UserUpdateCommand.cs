using System;
using System.ComponentModel.DataAnnotations;
using GMS.Models.Enums;
using GMS.Business.Handlers.Base;
using GMS.Models.ViewModels.UserViews;

namespace GMS.Business.Handlers.UserHandlers;

public class UserUpdateCommand : BaseUpdateCommand<UserViewModel>
{
    [Required(ErrorMessage = "Full Name is required.")]
    [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters.")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public Gender Gender { get; set; } = Gender.OTHER;

    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    public string? Email { get; set; }

    public DateTime? JoinDate { get; set; }

    public DateTime? HireDate { get; set; }

    [Range(0, (double)decimal.MaxValue, ErrorMessage = "Salary must be a non-negative value.")]
    public decimal? Salary { get; set; }

    [Range(0, (double)decimal.MaxValue, ErrorMessage = "Total Sales must be a non-negative value.")]
    public decimal? TotalSales { get; set; }

    [Range(0, 100.0, ErrorMessage = "Commission must be between 0 and 100.")]
    public decimal? Commission { get; set; }

    [StringLength(255, ErrorMessage = "Certificate cannot exceed 255 characters.")]
    public string? Certificate { get; set; }

    public DateTime? PackageEndDate { get; set; }

    [StringLength(50, ErrorMessage = "Employee Code cannot exceed 50 characters.")]
    public string? EmployeeCode { get; set; }

    public Guid? ManagerId { get; set; }

    public bool IsActive { get; set; }

    [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
    public string? Status { get; set; }

    public bool IsDeleted { get; set; }
}
