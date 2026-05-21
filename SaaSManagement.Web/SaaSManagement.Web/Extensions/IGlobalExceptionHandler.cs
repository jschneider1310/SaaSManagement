// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.AspNetCore.Diagnostics;

namespace SaaSManagement.Web.Extensions;

internal interface IGlobalExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken);
}