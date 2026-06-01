// Project: SaaSManagement, 29/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.ServicesManagement.Domain.Records;
using SaaSManagement.Core.Shared.Abstractions.Classes;
using SaaSManagement.Core.Shared.Constants;

namespace SaaSManagement.Core.ServicesManagement.Domain.Entities;

public sealed class Jurisdiction : Entity<string>
{
    
    [MaxLength(CoreConstants.ApplicationIdsMaxCharacters)] 
    public string JurisdictionId { get; private set; } = $"Jur-{Guid.CreateVersion7()}";
    [MaxLength(30)] public string JurisdictionName { get; private set; } 
    [MaxLength(256)] public string JurisdictionDescription { get; private set; }
    public Country Country { get; private set; }
    
    public Jurisdiction(string jurisdictionName, string jurisdictionDescription,
            Country country)
        {
            JurisdictionName = jurisdictionName
             ?? throw new ArgumentNullException(nameof(jurisdictionName));
    
            JurisdictionDescription = jurisdictionDescription
             ?? throw new ArgumentNullException(nameof(jurisdictionDescription));
    
            Country = country ?? throw new ArgumentNullException(nameof(country));
        }
    
    public override string GetId() => JurisdictionId;
}