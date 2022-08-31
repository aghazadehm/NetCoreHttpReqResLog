using Microsoft.Extensions.Primitives;

namespace WebApi.Helpers
{
    public static class HttpContextHelper
    {
        public static string GetCorrelationId(this HttpContext? httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));
            httpContext.Request.Headers.TryGetValue("Cko-Correlation-Id", out StringValues correlationId);
            return correlationId.FirstOrDefault() ?? httpContext.TraceIdentifier;
        }
    }
}
