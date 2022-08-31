using InsuranceApi.Helpers;
using System.Text.Json;
using WebApi.Configurations;
using WebApi.Logging;

namespace WebApi.Helpers
{
    public class HttpClientHelper
    {
        private readonly HttpClient _httpClient;
        private readonly string _area;
        private readonly ILoggerRepository _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpClientHelper(
            ILoggerRepository logger,
            IHttpContextAccessor httpContextAccessor,
            HttpClient httpClient,
            string area)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _httpClient = httpClient;
            _area = area;
        }
        public async Task<IEnumerable<TCollection>> GetCollectionsAsync<TCollection>(
            string token,
            string requestUri)
        {
            _httpClient.DefaultRequestHeaders.Add(Constants.AuthenticationConstants.Authentication, token);
            var reqResLog = new ReqResLogBuilder(_httpContextAccessor.HttpContext, DateTime.Now);
            var response = await _httpClient.GetAsync(_area + requestUri);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase, null, response.StatusCode);
            }

            var collection = JsonSerializer.Deserialize<IEnumerable<TCollection>>(await response.Content.ReadAsStringAsync());
            if (collection == null)
            {
                collection = new List<TCollection>();
            }

            reqResLog.AddHttpResponseMessage(response);
            reqResLog.AddCollectionRespone(collection);
            reqResLog.AddTokenRequestUserName("username comes from client");
            _logger.AddReqResLog(reqResLog.Build(DateTime.Now));

            return collection;
        }
    }
}
