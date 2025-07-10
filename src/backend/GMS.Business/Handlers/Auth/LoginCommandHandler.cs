using AutoMapper;
using GMS.Business.ConfigurationOptions;
using GMS.Business.Handlers.Base;
using GMS.Business.Services;
using GMS.Business.ViewModels.Auth;
using GMS.Data.UnitOfWorks;
using GMS.Models.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace GMS.Business.Handlers.Auth;

public class LoginCommandHandler(
    IUnitOfWork unitOfWork,
    ICustomMapper mapper,
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    ITokenService tokenService,
    IConfiguration configuration) :
    BaseHandler(unitOfWork, mapper),
    IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IConfiguration _configuration = configuration;

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // Find user by username
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid username or password");
        }

        // Check if the user is active
        if (!user.IsActive)
        {
            throw new UnauthorizedAccessException("Your account is deactivated. Please contact an administrator.");
        }

        // Check if the password is correct
        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (!result.Succeeded)
        {
            throw new UnauthorizedAccessException("Invalid username or password");
        }

        // Get user roles
        var userRoles = await _userManager.GetRolesAsync(user);

        // Generate access token
        var accessToken = await _tokenService.GenerateTokenAsync(user, userRoles);

        // Revoke any existing refresh tokens for security
        await _tokenService.RevokeUserRefreshTokensAsync(user.Id, "User logged in again");

        // Generate new refresh token
        var refreshTokenEntity = await _tokenService.GenerateRefreshTokenAsync(user.Id);

        // Get token expiration from config
        if (!int.TryParse(_configuration["JWT:AccessTokenExpiryMinutes"], out var expiryMinutes))
        {
            expiryMinutes = 15;
        }

        // Return response
        return new LoginResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshTokenEntity.Token,
            ExpiresAt = DateTime.UtcNow.AddMinutes(expiryMinutes)
        };
    }
}