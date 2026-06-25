// Project: LegalOfficeCRM
// Author: J. Schneider - j.g@live.com

using System.Security.Claims;
using SaaSManagement.Core.Identity.Implementations;

namespace SaaSManagement.Core.Identity.Contracts;

/// <summary>
/// Service for generating and validating JWT tokens.
/// </summary>
public interface IJwtTokenService
{
    /// <summary>
    /// Generates access and refresh tokens for a user.
    /// </summary>
    /// <param name="user">The application user.</param>
    /// <param name="tenantId">The tenant identifier.</param>
    /// <param name="securityInfo">Optional security information from the client.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Token response containing access and refresh tokens.</returns>
    Task<TokenResponse> GenerateTokensAsync(
        ApplicationUser user,
        string tenantId,
        SecurityInfo? securityInfo = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Validates a JWT access token and returns the claims principal.
    /// </summary>
    /// <param name="token">The JWT token to validate.</param>
    /// <returns>The claims principal if valid, null otherwise.</returns>
    Task<ClaimsPrincipal?> ValidateTokenAsync(string token);

    /// <summary>
    /// Refreshes tokens using a valid refresh token.
    /// </summary>
    /// <param name="refreshToken">The refresh token.</param>
    /// <param name="tenantId">The tenant identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>New token response if refresh token is valid, null otherwise.</returns>
    Task<TokenResponse?> RefreshTokenAsync(
        string refreshToken,
        string tenantId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Revokes a specific refresh token.
    /// </summary>
    /// <param name="refreshToken">The refresh token to revoke.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task RevokeRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);

    /// <summary>
    /// Revokes all refresh tokens for a user.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task RevokeAllUserTokensAsync(string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if a refresh token is valid and not revoked.
    /// </summary>
    /// <param name="refreshToken">The refresh token to check.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the token is valid, false otherwise.</returns>
    Task<bool> IsRefreshTokenValidAsync(string refreshToken, CancellationToken cancellationToken = default);
}