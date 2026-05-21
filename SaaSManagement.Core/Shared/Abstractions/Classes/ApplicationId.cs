// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.Shared.Constants;

namespace SaaSManagement.Core.Shared.Abstractions.Classes;
/// <summary>
/// Abstract class for all relevant ids used by the system.
/// </summary>
public abstract class ApplicationId : ValueObject
{
    
    [MaxLength(CoreConstants.ApplicationIdsMaxCharacters)]
    protected abstract string Value { get; set; }

    protected ApplicationId() { }

    protected ApplicationId(string value)
    {
        Value =  value;
    }

    public override string ToString() => Value;
}