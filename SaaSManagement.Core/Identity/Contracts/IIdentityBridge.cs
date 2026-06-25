// Project: LegalOfficeCRM, 07/10/2025
// Author: J. Schneider - j.g@live.com

using SaaSManagement.Core.Identity.Implementations;

namespace SaaSManagement.Core.Identity.Contracts;

/// <summary>
/// Manages identity user creation and synchronization
/// </summary>
public interface IIdentityBridge
{
    /// <summary>
    /// Creates an identity user for an existing entity
    /// </summary>
    Task<IdentityCreationResult> CreateIdentityUserAsync(
        string entityId,
        string userType,
        string email,
        string? password = null,
        string[]? roles = null,
        CancellationToken ct = default);

    /// <summary>
    /// Gets identity user ID by entity
    /// </summary>
    Task<string?> GetIdentityUserIdAsync(string entityId, string userType, CancellationToken ct = default);

    /// <summary>
    /// Synchronizes identity user data from the source entity
    /// </summary>
    Task SyncIdentityUserAsync(string identityUserId, CancellationToken ct = default);

    /// <summary>
    /// Removes identity access for an entity
    /// </summary>
    Task<bool> RemoveIdentityUserAsync(string entityId, string userType, CancellationToken ct = default);

    /// <summary>
    /// Checks if an entity has identity access
    /// </summary>
    Task<bool> HasIdentityAccessAsync(string entityId, string userType, CancellationToken ct = default);
}