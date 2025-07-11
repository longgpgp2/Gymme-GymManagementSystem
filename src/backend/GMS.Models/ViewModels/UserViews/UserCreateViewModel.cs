namespace GMS.Models.ViewModels.UserViews;

public class UserCreateViewModel
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? NormalizedUserName { get; set; }
    public string? Email { get; set; }
    public string? NormalizedEmail { get; set; }
    public bool EmailConfirmed { get; set; }
    public DateTime CreatedAt { get; set; }
    public required string Password { get; set; }
    public bool IsActive { get; set; }
    public string? SecurityStamp { get; set; }
    public required string Role { get; set; }
}