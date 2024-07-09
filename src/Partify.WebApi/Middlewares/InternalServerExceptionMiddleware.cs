﻿using Microsoft.AspNetCore.Diagnostics;
using Partify.WebApi.Models.Commons;

namespace Partify.WebApi.Middlewares;

public class InternalServerExceptionMiddleware(ILogger<InternalServerExceptionMiddleware> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        logger.LogError(exception.Message);

        await httpContext.Response.WriteAsJsonAsync(new Response
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Message = exception.Message,
        });

        return true;
    }
}
