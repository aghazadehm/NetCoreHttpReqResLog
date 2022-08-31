using InsuranceApi.Helpers;
using System.Net;
using WebApi.Logging;

namespace WebApi.Helpers
{
    public class ErrorLogBuilder
    {
        private readonly string _appName = "WebAi";
        private string _userName = string.Empty;
        private Exception _exception = default!;
        private HttpStatusCode _statusCode;
        private HttpContext _httpContext = default!;
        public ErrorLogBuilder(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }
        public ErrorLogBuilder AddTokenRequestUserName(string userName)
        {
            _userName = userName;
            return this;
        }
        internal ErrorLogBuilder AddStatusCode(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
            return this;
        }

        internal ErrorLogBuilder AddException(Exception exception)
        {
            _exception = exception;
            return this;
        }

        public ErrorLog Build()
        {
            return new ErrorLog
            {
                AppName = _appName,
                RequestCorrelationId = _httpContext.GetCorrelationId(),
                Exception = _exception.ToString(),
                ExceptionMessage = _exception.Message,
                RequestPath = _httpContext.Request.Path,
                UserName = _userName,
                StatusCode = (int)_statusCode,
                RequestMethod = _httpContext.Request.Method,
                RequestedOn = DateTime.Now
            };
        }
    }
}
