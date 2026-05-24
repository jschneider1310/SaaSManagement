// Project: SaaSManagement, 24/05/2026
// Author: J. Schneider - j.g@live.com

using System.ComponentModel.DataAnnotations;
using SaaSManagement.Core.Shared.Exceptions;
using SaaSManagement.Core.Shared.Utilities;
using ApplicationId = SaaSManagement.Core.Shared.Abstractions.Classes.ApplicationId;

namespace SaaSManagement.Core.Shared.Primitives;
/// <summary>
/// Strongly typed ID for <see cref="Note"/>
/// </summary>
public sealed class NoteId : ApplicationId
{
    [MaxLength(60)] protected override string Value { get; set; }
    
    public NoteId(string value)
    {
        if(!VerifyIf.IsNotEmptyOrNullString(value))
            throw new NoteArgumentException("Note id cannot be null or empty");
        
        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues() { yield return Value; }
}