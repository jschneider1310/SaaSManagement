// Project: SaaSManagement, 24/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using ApplicationId = SaaSManagement.Core.Shared.Abstractions.Classes.ApplicationId;

namespace SaaSManagement.Core.Shared.Primitives;

public sealed class ClientHistoryId : ApplicationId
{
    [MaxLength(60)] protected override string Value { get; set; }

    public ClientHistoryId(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("ClientHistoryId cannot be null or whitespace.",
                nameof(value));
        }

        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues() { yield return Value; }
}