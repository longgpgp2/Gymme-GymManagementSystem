using System;
using GMS.Models.Helpers;
using GMS.Models.Security;
using Microsoft.AspNetCore.Identity;

namespace GMS.Data.SeedData;

public static class DbInitializer
{
    public static async Task Initialize(GMSDbContext context, RoleManager<Role> roleManager, UserManager<User> userManager, string rolesJsonPath, string usersJsonPath)
    {
        await context.Database.EnsureCreatedAsync();

        await SeedUserAndRoleAsync(context, roleManager, userManager, rolesJsonPath, usersJsonPath);

    }

    private static async Task SeedUserAndRoleAsync(GMSDbContext context, RoleManager<Role> roleManager, UserManager<User> userManager, string rolesJsonPath, string usersJsonPath)
    {
        // Seed roles
        await SeedRolesAsync(roleManager, rolesJsonPath);

        // Seed users
        await SeedUsersAsync(userManager, usersJsonPath);

        await context.SaveChangesAsync();
    }

    private static async Task SeedUsersAsync(UserManager<User> userManager, string usersJsonPath)
    {
        if (userManager.Users.Any()) return;
        var users = SeedDataHelper.GetUsersAsync(usersJsonPath);
        System.Console.WriteLine($"Seeding {users.Count} users...");
        var passwordHasher = new PasswordHasher<User>();

        foreach (var userVm in users)
        {
            var existingUser = await userManager.FindByIdAsync(userVm.Id.ToString());
            if (existingUser == null)
            {
                var newUser = new User
                {
                    Id = userVm.Id,
                    UserName = userVm.UserName,
                    FullName = userVm.FullName ?? "",
                    NormalizedUserName = userVm.NormalizedUserName,
                    Email = userVm.Email ?? "",
                    NormalizedEmail = userVm.NormalizedEmail,
                    EmailConfirmed = true,
                    CreatedAt = userVm.CreatedAt,
                    IsActive = true,
                    SecurityStamp = userVm.SecurityStamp
                };

                newUser.PasswordHash = passwordHasher.HashPassword(newUser, userVm.Password);

                var result = await userManager.CreateAsync(newUser);

                if (result.Succeeded && !string.IsNullOrEmpty(userVm.Role))
                {
                    await userManager.AddToRoleAsync(newUser, userVm.Role);
                }
            }
        }
    }

    private static async Task SeedRolesAsync(RoleManager<Role> roleManager, string rolesJsonPath)
    {
        if (roleManager.Roles.Any()) return;
        var roles = SeedDataHelper.GetRoles(rolesJsonPath);
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role.Name ?? string.Empty))
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}