// Project: SaaSManagement, 29/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.Shared.Constants;
using ApplicationId = SaaSManagement.Core.Shared.Abstractions.Classes.ApplicationId;

namespace SaaSManagement.Core.ServicesManagement.Domain.Primitives;
/// <summary>
/// Represents the ID of any service into the system.
/// </summary>
public sealed class ServiceId : ApplicationId
{
    
    [MaxLength(CoreConstants.ApplicationIdsMaxCharacters)]
    protected override string Value { get; set; }
    
    public static implicit operator string(ServiceId id) => id.Value;
    public static implicit operator ServiceId(string id) => new(id);

    private ServiceId(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
 
}