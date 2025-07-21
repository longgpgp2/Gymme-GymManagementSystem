using System;
using System.ComponentModel.DataAnnotations;
using GMS.Models.ViewModels.Auth;
using MediatR;

namespace GMS.Business.Handlers.Auth;

public class LoginCommand : IRequest<LoginResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    [StringLength(50, ErrorMessage = "{0} must be at least {2} and at max {1} characters long", MinimumLength = 3)]
    public required string Username { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(20, ErrorMessage = "{0} must be at least {2} and at max {1} characters long", MinimumLength = 8)]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
