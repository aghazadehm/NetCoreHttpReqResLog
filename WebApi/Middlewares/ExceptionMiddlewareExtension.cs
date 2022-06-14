using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Reflection;
using WebApi.ErrorHandling;
using WebApi.Logging;

namespace WebApi.Middlewares
{
    public static class ExceptionMiddlewareExtension
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app, ILoggerRepository loggerRepository)
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
                        var errorLog = await GenerateErrorLog(context, contextFeature);
                        loggerRepository.AddErrorLog(errorLog); 

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error. => " + contextFeature.Error.Message,
                        }.ToString());
                    }
                });
            });
        }

        private static async Task<ErrorLog> GenerateErrorLog(HttpContext context, IExceptionHandlerFeature contextFeature)
        {
            var log = new ErrorLog
            {
                AppName = Assembly.GetEntryAssembly()?.GetName().Name,
                UserName = context.User?.Identity?.Name,
                StatusCode = context.Response.StatusCode,
                RequestPath = context.Request.Path,
                RequestMethod = context.Request.Method,
                RequestQueryString = context.Request.QueryString.ToString(),
                RequestedOn = DateTime.Now,
                Exception = contextFeature.Error.ToString(),
                ExceptionMessage = contextFeature.Error.Message,
            };
            // check if the Request is a POST call 
            // since we need to read from the body
            if (context.Request.Method == "POST")
            {
                context.Request.EnableBuffering();
                var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0;
                log.Payload = body;
            }
            return log;
        }
    }
}
