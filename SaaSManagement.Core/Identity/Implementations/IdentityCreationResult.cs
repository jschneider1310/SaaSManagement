// Project: LegalOfficeCRM, 07/10/2025
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Identity.Implementations;

/// <summary>
/// Result of an identity user creation operation
/// </summary>
public class IdentityCreationResult
{
    public bool Success { get; set; }
    public string? IdentityUserId { get; set; }
    public IEnumerable<string> Errors { get; set; } = [];

    public static IdentityCreationResult Succeeded(string identityUserId) => new()
    {
        Success = true,
        IdentityUserId = identityUserId
    };

    public static IdentityCreationResult Failed(params string[] errors) => new()
    {
        Success = false,
        Errors = errors
    };
}