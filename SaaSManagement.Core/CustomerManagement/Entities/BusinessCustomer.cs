// Project: SaaSManagement, 22/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.Shared.Primitives;

namespace SaaSManagement.Core.CustomerManagement.Entities;

public sealed class BusinessCustomer : Customer
{
    [MaxLength(60)] public string LegalName { get; private set; }
    [MaxLength(60)] public string FantasyName { get; private set; }
    [MaxLength(21)] public string RegistrationNumber { get; private set; }
    [MaxLength(40)] public string RegistrationBody { get; private set; }

}