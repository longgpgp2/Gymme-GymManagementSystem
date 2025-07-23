using System;
using System.ComponentModel.DataAnnotations;
using GMS.Models.Enums;
using GMS.Models.ViewModels.UserViews;
using MediatR;

namespace GMS.Business.Handlers.UserHandlers;

public class UserCreateCommand: IRequest<UserViewModel>
{
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Full Name is required.")]
    [StringLength(100, ErrorMessage = "Full Name cannot exceed 100 characters.")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public Gender Gender { get; set; } = Gender.OTHER;

    [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    public string? Email { get; set; }

    [Range(0, (double)decimal.MaxValue, ErrorMessage = "Salary must be a non-negative value.")]
    public decimal? Salary { get; set; }

    [StringLength(255, ErrorMessage = "Certificate cannot exceed 255 characters.")]
    public string? Certificate { get; set; }

    public bool IsActive { get; set; }

    [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
    public string? Status { get; set; }
}
