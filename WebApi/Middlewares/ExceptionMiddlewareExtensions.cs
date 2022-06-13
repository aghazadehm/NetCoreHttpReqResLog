﻿using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Reflection;
using WebApi.ErrorHandling;
using WebApi.Logging;

namespace WebApi.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerRepository logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.AddErrorLog(new ErrorLog
                        {
                            AppName = Assembly.GetEntryAssembly()?.GetName().Name,
                            UserName = context.User?.Identity?.Name,
                            StatusCode = context.Response.StatusCode,
                            Exception = contextFeature.Error.ToString(),
                            ExceptionMessage = contextFeature.Error.Message,
                            RequestedOn = DateTime.Now
                        }); 

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error. => " + contextFeature.Error.Message,
                        }.ToString());
                    }
                });
            });
        }
    }
}