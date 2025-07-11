using System;
using GMS.Models.ViewModels.Base;
using GMS.Models.Enums;

namespace GMS.Models.ViewModels.UserViews;

public class UserViewModel : BaseInfoViewModel
{
    public string? FullName { get; set; }

    public string? Email { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public Gender Gender { get; set; } = Gender.OTHER;

    public List<string> Roles { get; set; } = [];

    public string? Department { get; set; }

    public bool IsActive { get; set; }

    public string? Note { get; set; }
}
