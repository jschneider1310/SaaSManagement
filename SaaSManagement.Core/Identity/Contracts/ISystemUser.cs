// Project: SaaSManagement, 19/06/2026
// Author: J. Schneider - j.g@live.com

using SaaSManagement.Core.Identity.Enums;

namespace SaaSManagement.Core.Identity.Contracts;

/// <summary>
/// Represents any entity that can have system access
/// </summary>
public interface ISystemUser
{
    /// <summary>
    /// The primary Id for the entity.
    /// </summary>
    string Id { get; }

    /// <summary>
    /// The IdentityId provided by the identity provider
    /// </summary>
    string? IdentityId { get; set; }

    /// <summary>
    /// The unique name for the entity type.
    /// See <see cref="SystemUserTypes"/>
    /// </summary>
    string UserType { get; }

    /// <summary>
    /// Method that returns the display name for the system user
    /// </summary>
    /// <returns>String with the full name</returns>
    string GetDisplayName();

    /// <summary>
    /// Method that returns the email from the entity.
    /// </summary>
    /// <returns>String</returns>
    string GetEmail();
}