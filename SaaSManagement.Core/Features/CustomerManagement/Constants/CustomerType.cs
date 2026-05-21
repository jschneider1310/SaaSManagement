// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

namespace SaaSManagement.Core.Features.CustomerManagement.Constants;
/// <summary>
/// Defines the Customer Types using the system
/// </summary>
public enum CustomerType
{
    Student,
    Individual, // Single users of the system
    Associate, // Small group of system users
    Business, // Variable size of system users
    Enterprise, // Large system user size or on-premises implementation
    Organisation // Non-profit/special type with on-premises implementation
    
}