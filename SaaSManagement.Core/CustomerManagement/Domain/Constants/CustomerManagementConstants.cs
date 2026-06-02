// Project: SaaSManagement, 02/06/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.CustomerManagement.Domain.Constants;
/// <summary>
/// This class aggregates constants that are of use in all Customer Management code,
/// being a centralised way to change definitions.
/// </summary>
public static class CustomerManagementConstants
{
    public const int MaximumNameLength = 30; // For name and surname ( this value for each separately)
    public const int MaximumWebsiteLength = 256; // Maximum URI size
    public const int MaximumBusinessLegalOrFantasyNameLength = 60;
    public const int MaximumRegistrationNumberLength = 30;
    public const int MaximumRegistrationBodyNameLength = 40;

}