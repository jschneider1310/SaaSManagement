// Project: LegalOfficeCRM, 07/10/2025
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Identity.Contracts;

/// <summary>
/// Registry pattern to discover all ISystemUserService implementations
/// </summary>
public interface ISystemUserRegistry
{
    void Register(ISystemUserService service);
    ISystemUserService? GetService(string userType);
    IEnumerable<string> GetRegisteredUserTypes();
}