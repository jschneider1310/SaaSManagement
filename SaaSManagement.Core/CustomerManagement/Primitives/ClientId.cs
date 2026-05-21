// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.Shared.Constants;
using ApplicationId = SaaSManagement.Core.Shared.Abstractions.Classes.ApplicationId;

namespace SaaSManagement.Core.CustomerManagement.Primitives;
/// <summary>
/// Value Object class that represents an ID for any type of customer in this application.
/// </summary>
public sealed class ClientId : ApplicationId
{
    [MaxLength(CoreConstants.ApplicationIdsMaxCharacters)]
    protected override string Value { get; set; }


    public ClientId(string id)
    {
        Value = id;
    }

    public static implicit operator string(ClientId clientId) => clientId.Value;
    public static implicit operator ClientId(string clientId) => new(clientId);

    protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
}