// Project: LegalOfficeCRM, 02/10/2025
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Identity.Contracts;

/// <summary>
/// Service to manage the link between entities and their identity users
/// </summary>
public interface ISystemUserService
{
    /// <summary>
    /// The type identifier for this user service (e.g., "Client", "Staff")
    /// </summary>
    string UserType { get; }

    /// <summary>
    /// Gets the entity by its identity user ID
    /// </summary>
    Task<ISystemUser?> GetByIdentityIdAsync(string identityId, CancellationToken ct = default);

    /// <summary>
    /// Gets the entity by its own ID
    /// </summary>
    Task<ISystemUser?> GetByEntityIdAsync(string entityId, CancellationToken ct = default);

    /// <summary>
    /// Links an entity to an identity user
    /// </summary>
    Task<bool> LinkIdentityAsync(string entityId, string identityId, CancellationToken ct = default);

    /// <summary>
    /// Unlinks an entity from its identity user
    /// </summary>
    Task<bool> UnlinkIdentityAsync(string entityId, CancellationToken ct = default);
}