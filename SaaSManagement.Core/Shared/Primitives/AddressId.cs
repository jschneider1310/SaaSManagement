// Project: SaaSManagement, 27/05/2026
// Author: J. Schneider - j.g@live.com

using ApplicationId = SaaSManagement.Core.Shared.Abstractions.Classes.ApplicationId;

namespace SaaSManagement.Core.Shared.Primitives;
/// <summary>
/// Represents the ID of an <see cref="Address"/> into the system.
/// </summary>
public sealed class AddressId : ApplicationId
{
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    protected override string Value { get; set; }

    public AddressId()
    {
        Value = Guid.CreateVersion7().ToString();
    }
}