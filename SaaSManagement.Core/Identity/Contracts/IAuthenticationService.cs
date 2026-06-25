// Project: LegalOfficeCRM, 07/10/2025
// Author: J. Schneider - j.g@live.com
using Microsoft.AspNetCore.Identity;

namespace SaaSManagement.Core.Identity.Contracts;

/// <summary>
/// Service to handle authentication operations
/// </summary>
public interface IAuthenticationService
{
    Task<SignInResult> SignInAsync(string email, string password, bool rememberMe = false);
    Task SignOutAsync();
    Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
    Task<bool> ResetPasswordAsync(string userId, string token, string newPassword);
    Task<string?> GeneratePasswordResetTokenAsync(string email);
}