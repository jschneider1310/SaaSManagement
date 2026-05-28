// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using SaaSManagement.Core.Shared.Exceptions;
using SaaSManagement.Core.Shared.Utilities;

namespace SaaSManagement.Core.ServicesManagement.Records;

public sealed record HtmlEncodedText()
{
    public required string EncodedText { get; init; }

    public HtmlEncodedText(string encodedText) : this()
    {
        if(VerifyIf.IsNotEmptyOrNullString(encodedText))
            throw new SLAException("The encodedText must be a non-empty string.", nameof(HtmlEncodedText));
        
        EncodedText = encodedText;
    }
    
}