namespace InsuranceApi.ErrorHandling
{
    //public class ErrorLogGenerator
    //{
    //    public static async Task<ErrorLog> GenerateErrorLog(
    //        HttpContext context, 
    //        Exception exception)
    //    {
    //        var wrapperuserName = context.User?.Identity?.Name ?? string.Empty;
    //        var log = new ErrorLog
    //        {
    //            AppName = Assembly.GetEntryAssembly()?.GetName().Name,
    //            UserName = wrapperuserName,
    //            StatusCode = context.Response.StatusCode,
    //            RequestPath = context.Request.Path,
    //            RequestMethod = context.Request.Method,
    //            RequestQueryString = context.Request.QueryString.ToString(),
    //            RequestedOn = DateTime.Now,
    //            Exception = exception.ToString(),
    //            ExceptionMessage = exception.Message,
    //        };

    //        var requestType = await GetRequestType(context);
    //        switch (requestType)
    //        {
    //            case RequestType.Token:
    //                var username = GetUserNameFromBody();
    //                break;
    //            case RequestType.Get:
    //                break;
    //            case RequestType.Post:
    //                break;
    //            case RequestType.Delete:
    //                break;
    //            case RequestType.Put:
    //                break;
    //            case RequestType.Unknown:
    //            default:
    //                break;
    //        }
    //        // check if the Request is a POST call 
    //        // since we need to read from the body
    //        if (context.Request.Method == "POST")
    //        {
    //            log.Payload = _body;
    //        }
    //        return log;
    //    }

    //    private static async Task<RequestType> GetRequestType(HttpContext context)
    //    {
    //        if (context.Request.Method == "GET")
    //        {
    //            return RequestType.Get;
    //        }
    //        if (context.Request.Method == "POST")
    //        {
    //            if (_body.Contains(@"name=""UserName"""))
    //            {
    //                return RequestType.Token;
    //            }
    //            return RequestType.Post;
    //        }
    //        if (context.Request.Method == "PUT")
    //        {
    //            return RequestType.Put;
    //        }
    //        if (context.Request.Method == "DELETE")
    //        {
    //            return RequestType.Delete;
    //        }
    //        return RequestType.Unknown;
    //    }
    //}
}
