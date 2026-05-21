// Project: SaaSManagement, 21/05/2026
// Author: J. Schneider - j.g@live.com

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SaaSManagement.Web.Extensions;

internal sealed class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var status = exception switch
        {
            ArgumentException => StatusCodes.Status400BadRequest,
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };

        httpContext.Response.StatusCode = status;

        var problemDetails = new ProblemDetails
                             {
                                 Status = status,
                                 Title = "An error occurred.",
                                 Type = exception.GetType().Name,
                                 Detail = exception.Message
                             };

        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
                                                         {
                                                             Exception = exception,
                                                             HttpContext = httpContext,
                                                             ProblemDetails = problemDetails
                                                         }).ConfigureAwait(false);
    }
}