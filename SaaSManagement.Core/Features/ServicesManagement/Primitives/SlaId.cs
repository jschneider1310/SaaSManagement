// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.Shared.Constants;
using ApplicationId = SaaSManagement.Core.Shared.Abstractions.ApplicationId;

namespace SaaSManagement.Core.Features.ServicesManagement.Primitives;

public sealed class SlaId : ApplicationId
{
    [MaxLength(CoreConstants.ApplicationIdsMaxCharacters)]
    protected override string Value { get; set; }

    private SlaId(string id)
    {
        Value = id;
    }

    public static implicit operator string(SlaId slaId) => slaId.Value;
    public static implicit operator SlaId(string id) => new(id);

    protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
}