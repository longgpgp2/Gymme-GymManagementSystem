using System;
using System.Text.Json;
using GMS.Models.Security;
using GMS.Models.ViewModels.UserViews;
namespace GMS.Models.Helpers;

public class SeedDataHelper
{
    public static List<Role> GetRoles(string rolesJsonPath)
    {
        var json = File.ReadAllText(rolesJsonPath);
        return JsonSerializer.Deserialize<List<Role>>(json) ?? new List<Role>();
    }

    public static List<UserCreateViewModel> GetUsersAsync(string usersJsonPath)
    {
        var json = File.ReadAllText(usersJsonPath);
        return JsonSerializer.Deserialize<List<UserCreateViewModel>>(json) ?? new List<UserCreateViewModel>();
    }
    public static string GetRolesJsonPath()
    {
        return "SeedData/Roles.json";
    }

    public static string GetUsersJsonPath()
    {
        return "SeedData/Users.json";
    }

    public static string GetPermissionsJsonPath()
    {
        return "SeedData/Permissions.json";
    }
}
