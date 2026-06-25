// Project: SaaSManagement, 19/06/2026
// Author: J. Schneider - j.g@live.com
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SaaSManagement.Core.Identity.Implementations;
/// <summary>
/// The actual Identity user stored in AspNetUsers table.
/// Each tenant has its own database, so this user exists within the tenant's database.
/// No TenantId is needed as tenant isolation is achieved through separate databases.
/// </summary>
public sealed class ApplicationUser : IdentityUser
{
    /// <summary>
    /// Links to the source entity (Client, Staff, etc.)
    /// </summary>
    [MaxLength(35)]
    public string EntityId { get; set; } = string.Empty;

    /// <summary>
    /// Type of entity this user represents (e.g., "Staff", "Client")
    /// </summary>
    [MaxLength(35)]
    public string UserType { get; set; } = string.Empty;

    /// <summary>
    /// Cached display name for performance
    /// </summary>
    [MaxLength(50)]
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// The date and time when the user last logged in.
    /// </summary>
    public DateTime? LastLoginAt { get; set; }

    /// <summary>
    /// The IP address from the last login.
    /// </summary>
    [MaxLength(45)]
    public string? LastLoginIp { get; set; }

    /// <summary>
    /// The user agent from the last login.
    /// </summary>
    [MaxLength(500)]
    public string? LastLoginUserAgent { get; set; }

    public ICollection<IdentityUserClaim<string>>? Claims { get; set; }
    public ICollection<IdentityUserRole<string>>? UserRoles { get; set; }
    public ICollection<IdentityUserLogin<string>>? UserLogins { get; set; }
    public ICollection<IdentityUserToken<string>>? UserTokens { get; set; }
}