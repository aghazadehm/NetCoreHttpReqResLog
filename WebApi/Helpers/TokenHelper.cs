using Microsoft.Extensions.Primitives;

namespace InsuranceApi.Helpers
{
    public class TokenHelper
    {
        public static string GetTokenFromHttpRequest(IHttpContextAccessor accessor)
        {
            if (accessor.HttpContext.Request.Headers.TryGetValue(Constants.AuthenticationConstants.Authorization, out StringValues values))
            {
                var token = values.First().Split(" ")[1];
                return token;
            }

            return null;
        }
    }
}
